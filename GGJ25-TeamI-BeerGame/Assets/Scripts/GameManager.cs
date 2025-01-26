using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BattleUIControl battleUI;
    [SerializeField] GameRoundManager gameRoundManager;
    [SerializeField] RequestGenerator requestGenerator;
    [SerializeField] UnityEngine.KeyCode P1SendKey;
    [SerializeField] UnityEngine.KeyCode P2SendKey;
    [SerializeField] GameObject P1NoFull;
    [SerializeField] GameObject P2NoFull;
    [SerializeField] GameObject P1BeerWrong;
    [SerializeField] GameObject P2BeerWrong;
    [SerializeField] GameObject P1CupWrong;
    [SerializeField] GameObject P2CupWrong;



    public static GameManager instance;
    public CupHandler cupP1;
    public CupHandler cupP2;
    private void Awake(){
        instance = this;
    }
   

    private bool p1Spilled = false;
    private float p1SpillTime;
    private bool p2Spilled = false;
    private float p2SpillTime;




    private void Update() {
        if(!p1Spilled && cupP1.IsFull()){
            cupP1.ActivateSpill();
            p1Spilled = true;
            p1SpillTime = Time.time;
            
        }
        if(!p2Spilled && cupP2.IsFull()){
            cupP2.ActivateSpill();
            p2Spilled = true;
            p2SpillTime = Time.time;
        }

        if(p1Spilled && Time.time - p1SpillTime > 1f){
            cupP1.DeactivateSpill();
            p1Spilled = false;
            cupP1.Restart();
        }
        if(p2Spilled && Time.time - p2SpillTime > 1f){
            cupP2.DeactivateSpill();
            p2Spilled = false;
            cupP2.Restart();
        }

        if (Input.GetKeyDown(P1SendKey) && gameRoundManager.GetPlayer1Phase() == 3)
        {
            if (cupP1.GetPercentage() == -1)
            {
                P1NoFull.SetActive(true);
                return;
            }
            if (gameRoundManager.GetSelectBeer(1) != requestGenerator.GetCurrentBeer())
            {
                P1BeerWrong.SetActive(true);
                return;
            }
            if (gameRoundManager.GetSelectCup(1) != requestGenerator.GetCurrentCup())
            {
                P1CupWrong.SetActive(true);
                return;
            }




        }
        
        if (Input.GetKeyDown(P2SendKey) && gameRoundManager.GetPlayer2Phase() == 3)
        {
            if (cupP2.GetPercentage() == -1)
            {
                P2NoFull.SetActive(true);
                return;
            }
            if (gameRoundManager.GetSelectBeer(2) != requestGenerator.GetCurrentBeer())
            {
                P2BeerWrong.SetActive(true);
                return;
            }
            if (gameRoundManager.GetSelectCup(2) != requestGenerator.GetCurrentCup())
            {
                P2CupWrong.SetActive(true);
                return;
            }
        }
    }


    public void SendBeer(int playerID)
    {
        if (playerID == 1)
        {
            if (gameRoundManager.GetPlayer2Phase() == 4) JudgeRoundResult();
            else battleUI.StartCount(2);
        }
        else
        {
            if (gameRoundManager.GetPlayer1Phase() == 4) JudgeRoundResult();
            else battleUI.StartCount(1);
        }

    }

    public void JudgeRoundResult()
    {
        battleUI.DisableTimeCountUI();

        if (cupP2.GetPercentage() == -1 || gameRoundManager.GetSelectBeer(2) != requestGenerator.GetCurrentBeer() || gameRoundManager.GetSelectCup(2) != requestGenerator.GetCurrentCup())
        {
            gameRoundManager.GetPoint(1);
            return;
        }

        if (cupP1.GetPercentage() == -1 || gameRoundManager.GetSelectBeer(1) != requestGenerator.GetCurrentBeer() || gameRoundManager.GetSelectCup(1) != requestGenerator.GetCurrentCup())
        {
            gameRoundManager.GetPoint(2);
            return;
        }

        float p1Distance = Mathf.Abs(requestGenerator.GetCurrentPercent()- cupP1.GetPercentage());
        float p2Distance = Mathf.Abs(requestGenerator.GetCurrentPercent() - cupP2.GetPercentage());

        if (p1Distance < p2Distance) gameRoundManager.GetPoint(1);
        else if (p1Distance > p2Distance) gameRoundManager.GetPoint(2);
        else 
        {
            if (Random.Range(0, 2) > 0) gameRoundManager.GetPoint(1);
            else gameRoundManager.GetPoint(2);
        }
    }


}
