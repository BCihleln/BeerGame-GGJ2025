using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    [SerializeField] GameRoundManager gameRoundManager;
    [SerializeField] int[] player1Skills;
    [SerializeField] int[] player2Skills;
    [SerializeField] UnityEngine.KeyCode[] P1SkillBtn;
    [SerializeField] UnityEngine.KeyCode[] P2SkillBtn;

    [SerializeField] ShakingSkill shakingSkill; //搖晃別人桌子
    //遮擋對方杯子
    //操作打亂
    [SerializeField] SwapCupSkill swapCupSkill; //乾坤大挪移
    [SerializeField] PercentageSkill percentageSkill; //鑒定眼
    [SerializeField] ShadowSkill shadowSkill;//重影

    //private int[] player1Skills = new int[3];
    //private int[] player2Skills = new int[3];


    public int GetSkillName(int playerID, int skillOrder)
    {
        if (playerID == 1) return player1Skills[skillOrder-1];
        else return player2Skills[skillOrder-1];
    }

    private void Update()
    {
        if (gameRoundManager.GetPlayer1Phase() == 3)
        {
            for (int i = 0; i < 3; i++) 
            {
                if (Input.GetKeyDown(P1SkillBtn[i]))
                {
                    switch (player1Skills[i])
                    {
                        case 0: //搖晃別人桌子
                            shakingSkill.MoveCup(1);
                            break;
                        case 1: //遮擋對方杯子

                            break;
                        case 2: //操作打亂

                            break;
                        case 3: //乾坤大挪移
                            swapCupSkill.SwapCups();
                            break;
                        case 4: //鑒定眼
                            percentageSkill.P1ShowPercentage();
                            break;
                        case 5: //重影

                            break;
                    }

                    player1Skills[i] = -1;
                }
            }
        }

        if (gameRoundManager.GetPlayer2Phase() == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Input.GetKeyDown(P2SkillBtn[i]))
                {
                    switch (player2Skills[i])
                    {
                        case 0: //搖晃別人桌子
                            shakingSkill.MoveCup(2);
                            break;
                        case 1: //遮擋對方杯子

                            break;
                        case 2: //操作打亂

                            break;
                        case 3: //乾坤大挪移
                            swapCupSkill.SwapCups();
                            break;
                        case 4: //鑒定眼
                            percentageSkill.P2ShowPercentage();
                            break;
                        case 5: //重影

                            break;
                    }
                }
            }
        }
    }

}
