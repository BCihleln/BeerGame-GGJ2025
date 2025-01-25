using UnityEngine;
public void MoveCup(CupHandler cup, float speed, float time){
    if (time > 0)
    {
        time += Time.deltaTime;
        if(time < 1f){
            //move cup to the right
        } else if(time < 3f){
            //move cup to the left
        } else if(time < 4f){
            //move cup to the right
        } else {
            //stop moving
            time = 0f;
        }
    }
}
public class shakingSkill : MonoBehaviour
{
    public UnityEngine.KeyCode P1SkillBtn;
    public UnityEngine.KeyCode P2SkillBtn;
    public float ShakeTime = 4f;
    public float moveSpeed = 0.1f;

    public CupHandler cupP1;
    public CupHandler cupP2;

    private void Update()
    {
        CheckSkillActivationP1();
        CheckSkillActivationP2();
    }
    private void CheckSkillActivationP1()
    {
        if (Input.GetKeyDown(P1SkillBtn))
        {
            MoveCup(cupP2, moveSpeed, ShakeTime);
        }
    }
    private void CheckSkillActivationP2()
    {
        if (Input.GetKeyDown(P2SkillBtn))
        {
            MoveCup(cupP1, moveSpeed, ShakeTime);
        }
    }
}