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

    private bool p1Spilled = false;
    private float p1SpillTime;
    private bool p2Spilled = false;
    private float p2SpillTime;

    private void Start() {
        Restart();
    }

    private void Update() {
        if(!p1Spilled && cupP1.IsFull()){
            cupP1.ActivateSpill();
            p1Spilled = true;
            p1SpillTime = Time.time;
            
        }
        if(!p2Spilled && cupP2.IsFull()){
            cupP2.ActivateSpill();
            p2Spilled = true;
            p2SpillTime = Time.time;
        }

        if(p1Spilled && Time.time - p1SpillTime > 1f){
            cupP1.DeactivateSpill();
            p1Spilled = false;
            cupP1.Restart();
        }
        if(p2Spilled && Time.time - p2SpillTime > 1f){
            cupP2.DeactivateSpill();
            p2Spilled = false;
            cupP2.Restart();
        }
    }

    private void Restart(){
        sentTime = -1;
        p1Sent = false;
        p2Sent = false;
    }
}
