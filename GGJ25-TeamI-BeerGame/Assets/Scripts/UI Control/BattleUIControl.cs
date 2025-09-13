using UnityEngine;
using UnityEngine.UIElements;

public class BattleUIControl : MonoBehaviour
{
    [SerializeField] BattleUISO battleUISO;
    [SerializeField] SkillSO skillSOData;
    [SerializeField] GameRoundManager gameRoundManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject P1Can;
    [SerializeField] GameObject P1Cup;
    [SerializeField] GameObject P2Can;
    [SerializeField] GameObject P2Cup;
    [SerializeField] string Player1Left = "a";
    [SerializeField] string Player1Right = "d";
    [SerializeField] string Player1Submit = "f";
    [SerializeField] string Player2Left = "left";
    [SerializeField] string Player2Right = "right";
    [SerializeField] string Player2Submit = "[0]";
    [SerializeField] float SubmitTime = 3f;

    private int _currentP1Select = 0;
    private int _currentP2Select = 0;
    private SkillSystem skillSystem;
    private float _p1CountTime = 0f;
    private bool _p1StartCount = false;
    private float _p2CountTime = 0f;
    private bool _p2StartCount = false;


    VisualElement rootVisualElement;

    Label customerLeft;
    Label player1BubbleRatio;
    Label player2BubbleRatio;
    Label player1TimeLeft;
    Label player2TimeLeft;

    VisualElement player1SelectPic;
    VisualElement player1LeftPic;
    VisualElement player1RightPic;
    VisualElement player2SelectPic;
    VisualElement player2LeftPic;
    VisualElement player2RightPic;

    Label[] player1SkillName = new Label[4];
    Label[] player2SkillName = new Label[4];
    VisualElement[] player1SkillPic = new VisualElement[4];
    VisualElement[] player2SkillPic = new VisualElement[4];
    VisualElement[] player1PointPicture = new VisualElement[8];
    VisualElement[] player2PointPicture = new VisualElement[8];

    public void TotalInitialUI()
    {
        player1TimeLeft.visible = false;
        player2TimeLeft.visible = false;
        player1BubbleRatio.visible = false;
        player2BubbleRatio.visible = false;

        P1Can.SetActive(false);
        P1Cup.SetActive(false);
        P2Can.SetActive(false);
        P2Cup.SetActive(false);

        for (int i = 1; i < 8; i++)
        {
            player1PointPicture[i].visible = false;
            player2PointPicture[i].visible = false;
        }
        gameRoundManager.RestartRound(1);
        gameRoundManager.RestartRound(2);
        customerLeft.text = gameRoundManager.GetCurrentCustomerLeft().ToString();
        
        for (int i = 1; i < 4; i++)
        {
            player1SkillName[i].text = skillSOData.skillNames[skillSystem.GetSkillName(1, i)];
            player1SkillPic[i].style.backgroundImage = new StyleBackground(skillSOData.skillPictures[skillSystem.GetSkillName(1, i)]);
            player2SkillName[i].text = skillSOData.skillNames[skillSystem.GetSkillName(2, i)];
            player2SkillPic[i].style.backgroundImage = new StyleBackground(skillSOData.skillPictures[skillSystem.GetSkillName(2, i)]);
        }
    }

    public void RoundInitial()
    {
        player1TimeLeft.visible = false;
        player2TimeLeft.visible = false;
        player1BubbleRatio.visible = false;
        player2BubbleRatio.visible = false;

        P1Can.SetActive(false);
        P1Cup.SetActive(false);
        P2Can.SetActive(false);
        P2Cup.SetActive(false);

        gameRoundManager.RestartRound(1);
        gameRoundManager.RestartRound(2);
        customerLeft.text = gameRoundManager.GetCurrentCustomerLeft().ToString();
    }

    public void Player1GetPoint(int currentPoint) { player1PointPicture[currentPoint].visible = true; }
    public void Player2GetPoint(int currentPoint) { player2PointPicture[currentPoint].visible = true; }
    public void PhaseUIChange(int playerID)
    {
        if (playerID == 1)
        {
            var phaseID1 = gameRoundManager.GetPlayer1Phase();

            _currentP1Select = 0;

            player1BubbleRatio.visible = false;

            P1Can.SetActive(false);
            P1Cup.SetActive(false);


            if (phaseID1 == GameRoundManager.GamePhase.SelectBeer)
            {
                player1SelectPic.visible = true;
                player1LeftPic.visible = true;
                player1RightPic.visible = true;

                player1SelectPic.style.backgroundImage = new StyleBackground(battleUISO.beerPicture[0]);

            }
            else if (phaseID1 == GameRoundManager.GamePhase.SelectCup)
            {
                player1SelectPic.visible = true;
                player1LeftPic.visible = true;
                player1RightPic.visible = true;

                player1SelectPic.style.backgroundImage = new StyleBackground(battleUISO.cupPicture[0]);
            }
            else if (phaseID1 == GameRoundManager.GamePhase.Pouring)
            {
                player1SelectPic.visible = false;
                player1LeftPic.visible = false;
                player1RightPic.visible = false;

                P1Can.SetActive(true);
                P1Cup.SetActive(true);
            }
            else
            {
                P1Cup.SetActive(false);
            }


        }
        else
        {
            var phaseID2 = gameRoundManager.GetPlayer2Phase();
            _currentP2Select = 0;

            player2BubbleRatio.visible = false;

            P2Can.SetActive(false);
            P2Cup.SetActive(false);

            if (phaseID2 == GameRoundManager.GamePhase.SelectBeer)
            {
                player2SelectPic.visible = true;
                player2LeftPic.visible = true;
                player2RightPic.visible = true;

                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.beerPicture[0]);

            }
            else if (phaseID2 == GameRoundManager.GamePhase.SelectCup)
            {
                player2SelectPic.visible = true;
                player2LeftPic.visible = true;
                player2RightPic.visible = true;

                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.cupPicture[0]);
            }
            else if (phaseID2 == GameRoundManager.GamePhase.Pouring)
            {
                player2SelectPic.visible = false;
                player2LeftPic.visible = false;
                player2RightPic.visible = false;

                P2Can.SetActive(true);
                P2Cup.SetActive(true);
            }
            else
            {
                P2Cup.SetActive(false);
            }
        }
    }
    public void UpdateSelectUI(int playerID)
    {
        if (playerID == 1)
        {
            if (gameRoundManager.GetPlayer1Phase() == GameRoundManager.GamePhase.SelectBeer)
            {
                player1SelectPic.style.backgroundImage = new StyleBackground(battleUISO.beerPicture[_currentP1Select]);
            }
            else
            {
                player1SelectPic.style.backgroundImage = new StyleBackground(battleUISO.cupPicture[_currentP1Select]);
            }
        }
        else
        {
            if (gameRoundManager.GetPlayer2Phase() == GameRoundManager.GamePhase.SelectBeer)
            {
                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.beerPicture[_currentP2Select]);
            }
            else
            {
                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.cupPicture[_currentP2Select]);
            }

        }
    }

    public void EnableBubbleRatio(int playerID, string percentText)
    {
        if (playerID == 1)
        {
            player1BubbleRatio.visible = true;
            player1BubbleRatio.text = percentText;
        }
        else
        {
            player2BubbleRatio.visible = true;
            player2BubbleRatio.text = percentText;
        }
    }

    public void DisableBubbleRatio(int playerID)
    {
        if (playerID == 1) player1BubbleRatio.visible = false;
        else player2BubbleRatio.visible = false;
    }

    public void StartCount(int playerID)
    {
        if (playerID == 1)
        {
            player1TimeLeft.visible = true;
            _p1StartCount = true;
            _p1CountTime = Time.time;
        }
        else
        {
            player2TimeLeft.visible = true;
            _p2StartCount = true;
            _p2CountTime = Time.time;
        }
    }

    public void DisableTimeCountUI()
    {
        player1TimeLeft.visible = false;
        _p1StartCount = false;
        player2TimeLeft.visible = false;
        _p2StartCount = false;
    }


    private void Start()
    {

        skillSystem = GameObject.Find("SkillManager").GetComponent<SkillSystem>();

        rootVisualElement = GetComponent<UIDocument>().rootVisualElement;

        customerLeft = rootVisualElement.Q<Label>("CustomerLeft");
        player1BubbleRatio = rootVisualElement.Q<Label>("P1BubbleRatio");
        player2BubbleRatio = rootVisualElement.Q<Label>("P2BubbleRatio");
        player1TimeLeft = rootVisualElement.Q<Label>("P1TimeCount");
        player2TimeLeft = rootVisualElement.Q<Label>("P2TimeCount");
        player1SelectPic = rootVisualElement.Q<VisualElement>("P1SelectPicture");
        player1LeftPic = rootVisualElement.Q<VisualElement>("P1LeftSelect");
        player1RightPic = rootVisualElement.Q<VisualElement>("P1RightSelect");
        player2SelectPic = rootVisualElement.Q<VisualElement>("P2SelectPicture");
        player2LeftPic = rootVisualElement.Q<VisualElement>("P2LeftSelect");
        player2RightPic = rootVisualElement.Q<VisualElement>("P2RightSelect");

        for (int i = 1; i < 4; i++)
        {
            player1SkillName[i] = rootVisualElement.Q<Label>("P1S" + i.ToString() + "Name");
            player2SkillName[i] = rootVisualElement.Q<Label>("P2S" + i.ToString() + "Name");
            player1SkillPic[i] = rootVisualElement.Q<VisualElement>("P1S" + i.ToString() + "Picture");
            player2SkillPic[i] = rootVisualElement.Q<VisualElement>("P2S" + i.ToString() + "Picture");
        }

        for (int i = 1; i < 8; i++)
        {
            player1PointPicture[i] = rootVisualElement.Q<VisualElement>("P1Point" + i.ToString());
            player1PointPicture[i].visible = false;
            player2PointPicture[i] = rootVisualElement.Q<VisualElement>("P2Point" + i.ToString());
            player2PointPicture[i].visible = false;
        }

        TotalInitialUI();
    }

    private void Update()
    {
        //player1

        if (gameRoundManager.GetPlayer1Phase() != GameRoundManager.GamePhase.Pouring)
        {
            if (Input.GetKeyDown(Player1Left))
            {
                if (_currentP1Select == 0) _currentP1Select = 2;
                else _currentP1Select--;
                UpdateSelectUI(1);
            }
            if (Input.GetKeyDown(Player1Right))
            {
                if (_currentP1Select == 2) _currentP1Select = 0;
                else _currentP1Select++;
                UpdateSelectUI(1);
            }
            if (Input.GetKeyDown(Player1Submit))
            {
                if (gameRoundManager.GetPlayer1Phase() == GameRoundManager.GamePhase.SelectBeer)
                {
                    P1Can.GetComponent<BeerHandler>().SelectBeer(_currentP1Select);
                    gameRoundManager.SelectBeer(1, _currentP1Select);
                }
                else
                {
                    P1Cup.GetComponent<CupHandler>().SelectCup(_currentP1Select);
                    gameRoundManager.SelectCup(1, _currentP1Select);
                }


                gameRoundManager.NextPhase(1);
                
            }
        }

        //player2
        if (gameRoundManager.GetPlayer2Phase() != GameRoundManager.GamePhase.Pouring)
        {
            if (Input.GetKeyDown(Player2Left))
            {
                if (_currentP2Select == 0) _currentP2Select = 2;
                else _currentP2Select--;
                UpdateSelectUI(2);
            }
            if (Input.GetKeyDown(Player2Right))
            {
                if (_currentP2Select == 2) _currentP2Select = 0;
                else _currentP2Select++;
                UpdateSelectUI(2);
            }
            if (Input.GetKeyDown(Player2Submit))
            {
                if (gameRoundManager.GetPlayer2Phase() == GameRoundManager.GamePhase.SelectBeer)
                {
                    P2Can.GetComponent<BeerHandler>().SelectBeer(_currentP2Select);
                    gameRoundManager.SelectBeer(2, _currentP2Select);
                }
                else
                {
                    P2Cup.GetComponent<CupHandler>().SelectCup(_currentP2Select);
                    gameRoundManager.SelectCup(2, _currentP2Select);
                }
                gameRoundManager.NextPhase(2);
            }
        }

        if (_p1StartCount)
        {
            float tempTime1 = SubmitTime - Time.time + _p1CountTime;

            if (tempTime1 < 0 ) tempTime1 = 0;
            player1TimeLeft.text = tempTime1.ToString("0.0");

            if (tempTime1 == 0)
            {
                _p1StartCount = false;
                gameManager.JudgeRoundResult();
            }

        }
       
        if (_p2StartCount)
        {
            float tempTime2 = SubmitTime - Time.time + _p2CountTime;

            if (tempTime2 < 0) tempTime2 = 0;
            player2TimeLeft.text = tempTime2.ToString("0.0");

            if (tempTime2 == 0)
            {
                _p2StartCount = false;
                gameManager.JudgeRoundResult();
            }
        }


    }






}
