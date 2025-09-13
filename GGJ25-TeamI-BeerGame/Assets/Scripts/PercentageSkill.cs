using UnityEngine;

public class PercentageSkill:MonoBehaviour
{
    [SerializeField] BattleUIControl battleUI;
    [SerializeField] CupHandler cupP1;
    [SerializeField] CupHandler cupP2;
    [SerializeField] float skillTime = 3f;

    private bool P1ShowPercentageSwitch = false;
    private bool P2ShowPercentageSwitch = false;
    private float P1StartTime = 0f;
    private float P2StartTime = 0f;

    public void P1ShowPercentage()
    {
        P1ShowPercentageSwitch = true; 

        string text1 = "0.00%";

        if (cupP1.GetSkillPercentage() * 100 != 0) text1 = (cupP1.GetSkillPercentage() * 100).ToString("0.00") + "%";

        battleUI.EnableBubbleRatio(1, text1);

        P1StartTime = Time.time;

    }
    public void P2ShowPercentage()
    { 

        P2ShowPercentageSwitch = true;

        string text1 = "0.00%";

        if (cupP2.GetSkillPercentage() * 100 != 0) text1 = (cupP2.GetSkillPercentage() * 100).ToString("0.00") + "%";

        battleUI.EnableBubbleRatio(2, text1);

        P2StartTime = Time.time;

    }

    private void Update()
    {
        if (P1ShowPercentageSwitch)
        {
            if (Time.time - P1StartTime >= skillTime)
            {
                battleUI.DisableBubbleRatio(1);
                P1ShowPercentageSwitch = false;
            }
        }
        if (P2ShowPercentageSwitch)
        {
            if (Time.time - P2StartTime >= skillTime)
            {
                battleUI.DisableBubbleRatio(2);
                P2ShowPercentageSwitch = false;
            }
        }
    }




}