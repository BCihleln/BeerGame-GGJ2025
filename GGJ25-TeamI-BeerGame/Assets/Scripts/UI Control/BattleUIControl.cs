using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class BattleUIControl : MonoBehaviour
{
    [SerializeField] BattleUISO battleUISO;
    [SerializeField] SkillSO skillSOData;
    [SerializeField] GameRoundManager gameRoundManager;
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

    private int _currentP1Select = 0;
    private int _currentP2Select = 0;
    private SkillSystem skillSystem;

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

        for (int i = 1; i < 8; i++)
        {
            player1PointPicture[i].visible = false;
            player2PointPicture[i].visible = false;
        }
        gameRoundManager.ChangePhase(1, 1);
        gameRoundManager.ChangePhase(2, 1);
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
        gameRoundManager.ChangePhase(1, 1);
        gameRoundManager.ChangePhase(2, 1);
        customerLeft.text = gameRoundManager.GetCurrentCustomerLeft().ToString();
    }

    public void Player1GetPoint(int currentPoint) { player1PointPicture[currentPoint].visible = true; }
    public void Player2GetPoint(int currentPoint) { player2PointPicture[currentPoint].visible = true; }
    public void PhaseUIChange(int playerID)
    {
        if (playerID == 1)
        {
            int phaseID1 = gameRoundManager.GetPlayer1Phase();

            _currentP1Select = 0;

            if (phaseID1 == 1)
            {
                player1SelectPic.visible = true;
                player1LeftPic.visible = true;
                player1RightPic.visible = true;

                player1SelectPic.style.backgroundImage = new StyleBackground(battleUISO.beerPicture[0]);

            }
            else if (phaseID1 == 2)
            {
                player1SelectPic.visible = true;
                player1LeftPic.visible = true;
                player1RightPic.visible = true;

                player1SelectPic.style.backgroundImage = new StyleBackground(battleUISO.cupPicture[0]);
            }
            else
            {
                player1SelectPic.visible = false;
                player1LeftPic.visible = false;
                player1RightPic.visible = false;

                P1Can.SetActive(true);
                P1Cup.SetActive(true);
            }

        }
        else
        {
            int phaseID2 = gameRoundManager.GetPlayer2Phase();
            _currentP2Select = 0;

            if (phaseID2 == 1)
            {
                player2SelectPic.visible = true;
                player2LeftPic.visible = true;
                player2RightPic.visible = true;

                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.beerPicture[0]);

            }
            else if (phaseID2 == 2)
            {
                player2SelectPic.visible = true;
                player2LeftPic.visible = true;
                player2RightPic.visible = true;

                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.cupPicture[0]);
            }
            else
            {
                player2SelectPic.visible = false;
                player2LeftPic.visible = false;
                player2RightPic.visible = false;

                P2Can.SetActive(true);
                P2Cup.SetActive(true);
            }
        }
    }
    public void UpdateSelectUI(int playerID)
    {
        if (playerID == 1)
        {
            if (gameRoundManager.GetPlayer1Phase() == 1)
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
            if (gameRoundManager.GetPlayer2Phase() == 1)
            {
                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.beerPicture[_currentP2Select]);
            }
            else
            {
                player2SelectPic.style.backgroundImage = new StyleBackground(battleUISO.cupPicture[_currentP2Select]);
            }

        }
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

        if (gameRoundManager.GetPlayer1Phase() != 3)
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
                //call select function
                gameRoundManager.NextPhase(1);
            }
        }

        //player2
        if (gameRoundManager.GetPlayer2Phase() != 3)
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
                //call select function
                gameRoundManager.NextPhase(2);
            }
        }

    }






}
