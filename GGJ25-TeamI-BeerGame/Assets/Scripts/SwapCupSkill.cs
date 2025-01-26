using UnityEngine;

public class SwapCupSkill : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public KeyCode P1SkillBtn = KeyCode.C;
    public KeyCode P2SkillBtn = KeyCode.Period;

    public CupHandler cupP1;
    public CupHandler cupP2;
    private CupHandler temp;
    void Start()
    {
        
    }

    public void SwapCups()
    {
        // Swap all relevant data between cup1 and cup2
        var tempData = cupP1.GetData();
        cupP1.SetData(cupP2.GetData());
        cupP2.SetData(tempData);
    }
}
