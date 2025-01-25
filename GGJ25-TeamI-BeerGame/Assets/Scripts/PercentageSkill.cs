using UnityEngine;
using TMPro;

public class PercentageSkill:MonoBehaviour
{
    public TMP_Text P1text;
    public TMP_Text P2text;
    public CupHandler cupP1;
    public CupHandler cupP2;
    private bool P1ShowPercentageSwitch = false;
    private bool P2ShowPercentageSwitch = false;

    private void Start()
    {
        P1text = GameObject.Find("P1Text").GetComponent<TMP_Text>();
        P2text = GameObject.Find("P2Text").GetComponent<TMP_Text>();
        P1text.text = "";
        P2text.text = "";
        P1text.gameObject.SetActive(false);
        P2text.gameObject.SetActive(false);
    }
    private void Update()
    {
        CheckSkillActivationP1();
        CheckSkillActivationP2();
        if(P1ShowPercentageSwitch){
            P1ShowPercentage();
        }
        if(P2ShowPercentageSwitch){
            P2ShowPercentage();
        }
    }
    private void P1ShowPercentage(){
        P1text.text = "P1: " + (cupP1.GetSkillPercentage()*100).ToString() + "%";
    }
    private void P2ShowPercentage(){
        P2text.text = "P2: " + (cupP2.GetSkillPercentage()*100).ToString() + "%";
    }
    private void CheckSkillActivationP1(){
        if (Input.GetKeyDown(KeyCode.X)){
            // Activate skill
            P1text.gameObject.SetActive(true);
            P1ShowPercentageSwitch = true;
        }
    }
    private void CheckSkillActivationP2(){
        if (Input.GetKeyDown(KeyCode.RightShift)){
            // Activate skill
            P2text.gameObject.SetActive(true);
            P2ShowPercentageSwitch = true;
        }
    }
}