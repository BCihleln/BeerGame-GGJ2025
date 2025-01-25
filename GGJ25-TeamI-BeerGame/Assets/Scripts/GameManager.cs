using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CupHandler cupP1;
    public CupHandler cupP2;
    private void Awake(){
        instance = this;
    }
    
    private float sentPercentP1;
    private float sentPercentP2;
    private float needPercent = 0.3f;
    private float sentTime = -1;
    private bool p1Sent = false;
    private bool p2Sent = false;

    private void Start() {
        Restart();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            Restart(1); Restart(2);
        }
        if(cupP1.IsFull()){
            cupP1.Restart();
        }
        if(cupP2.IsFull()){
            cupP2.Restart();
        }

        if(Input.GetKeyDown(KeyCode.RightShift)){
            sentPercentP2 = cupP2.GetPercentage();
            if(sentPercentP2 != -1){
                p2Sent = true;
                sentTime = Time.time;
                Debug.Log("enough beer!");
            }
            Debug.Log(sentPercentP2);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            sentPercentP1 = cupP1.GetPercentage();
            if(sentPercentP1 != -1){
                p1Sent = true;
                sentTime = Time.time;
                Debug.Log("enough beer!");
            }
            Debug.Log(sentPercentP1);
        }

        if (p1Sent && Time.time - sentTime >= 3f && !p2Sent) {
            sentPercentP2 = cupP2.GetPercentage();
        }
        if (p2Sent && Time.time - sentTime >= 3f && !p1Sent) {
            sentPercentP1 = cupP1.GetPercentage();
        }

        if(Time.time - sentTime >= 3f){
            Judge();
        }
    }

    public void Restart(int index){
        if(index == 1){
            cupP1.Restart();
        }
        else{
            cupP2.Restart();
        }
        p1Sent = false;
        p2Sent = false;
    }

    public int Judge(){
        if (sentPercentP1 == -1) {
            return 2;
        }
        if (sentPercentP2 == -1) {
            return 1;
        }
        
        //P1 win if ties
        if (Mathf.Abs(sentPercentP1 - needPercent) <= Mathf.Abs(sentPercentP2 - needPercent)) {
            return 1;
        } else {
            return 2;
        }
    }

    private void Restart(){
        sentTime = -1;
        p1Sent = false;
        p2Sent = false;
    }
}
