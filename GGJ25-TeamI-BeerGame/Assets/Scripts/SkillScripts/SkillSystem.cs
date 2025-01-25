using UnityEngine;

public class SkillSystem : MonoBehaviour
{

    [SerializeField] int[] player1Skills;
    [SerializeField] int[] player2Skills;

    //private int[] player1Skills = new int[3];
    //private int[] player2Skills = new int[3];


    public int GetSkillName(int playerID, int skillOrder)
    {
        if (playerID == 1) return player1Skills[skillOrder-1];
        else return player2Skills[skillOrder-1];
    }

}
