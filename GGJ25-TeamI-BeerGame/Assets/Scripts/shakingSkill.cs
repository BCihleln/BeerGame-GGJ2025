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
    public void MoveCup(int cupID){
        
        if (cupID == 1) cupP2.MoveCupSkill(moveSpeed);
        else cupP1.MoveCupSkill(moveSpeed);
    }
}