using UnityEngine;

public class ShakingSkill : MonoBehaviour
{
    public UnityEngine.KeyCode P1SkillBtn = KeyCode.Z;
    public UnityEngine.KeyCode P2SkillBtn = KeyCode.Comma;
    public float moveSpeed = 50f;

    public CupHandler cupP1;
    public CupHandler cupP2;

    private void Start()
    {
        Application.runInBackground = true;
    }

    private void Update()
    {
        CheckSkillActivationP1();
        CheckSkillActivationP2();
    }
    private void CheckSkillActivationP1()
    {
        if (Input.GetKeyDown(P1SkillBtn))
        {
            MoveCup(cupP2, moveSpeed);
            Debug.Log("P1 used skill");
        }
    }
    private void CheckSkillActivationP2()
    {
        if (Input.GetKeyDown(P2SkillBtn))
        {
            MoveCup(cupP1, moveSpeed);
            Debug.Log("P2 used skill");
        }
    }
    private void MoveCup(CupHandler cup, float speed){
        cup.MoveCupSkill(speed);
    }
}