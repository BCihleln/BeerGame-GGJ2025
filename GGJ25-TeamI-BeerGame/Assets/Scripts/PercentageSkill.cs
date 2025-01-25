using UnityEngine;
using TMPro;

public class PercentageSkill:MonoBehaviour
{
    private TMP_Text P1text;
    private TMP_Text P2text;
    public CupHandler cupP1;
    public CupHandler cupP2;

    private void Start()
    {
        P1text = GameObject.Find("P1Text").GetComponent<TMP_Text>();
        P2text = GameObject.Find("P2Text").GetComponent<TMP_Text>();
        P1text.text = "";
        P2text.text = "";
    }
    private void Update()
    {
        CheckSkillActivationP1();
        CheckSkillActivationP2();
    }
    private void P1ShowPercentage(){
        P1text.text = "P1: " + cupP1.GetPercentage().ToString() + "%";
    }
    private void P2ShowPercentage(){
        P2text.text = "P2: " + cupP2.GetPercentage().ToString() + "%";
    }
    private void CheckSkillActivationP1(){
        if (Input.GetKeyDown(KeyCode.X)){
            // Activate skill
            P1ShowPercentage();
        }
    }
    private void CheckSkillActivationP2(){
        if (Input.GetKeyDown(KeyCode.RightShift)){
            // Activate skill
            P2ShowPercentage();
        }
    }
}