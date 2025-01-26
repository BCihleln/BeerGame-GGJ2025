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

    // Update is called once per frame
    void Update()
    {
        //swap the cups
        if (Input.GetKeyDown(P1SkillBtn) || Input.GetKeyDown(P2SkillBtn))
        {
            SwapCups(cupP1, cupP2);
            Debug.Log("Cups swapped");
        }
    }

    void SwapCups(CupHandler cup1, CupHandler cup2)
    {
        // Swap all relevant data between cup1 and cup2
        var tempData = cup1.GetData();
        cup1.SetData(cup2.GetData());
        cup2.SetData(tempData);
    }
}
