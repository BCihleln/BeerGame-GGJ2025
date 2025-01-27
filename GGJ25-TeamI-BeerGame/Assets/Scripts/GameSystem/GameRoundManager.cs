using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameRoundManager : MonoBehaviour
{
    [SerializeField] BattleUIControl BattleUI;
    [SerializeField] RequestGenerator requestGenerator;
    [SerializeField] UnityEvent OnGameEnd;
    [SerializeField] GameObject Player1RoundEndUI; // Round end UI
    [SerializeField] GameObject Player2RoundEndUI; // Round end UI
    [SerializeField] float RoundWaitTime = 2f;

    private int _currentCustomerLeft = 7;
    private int _player1Point = 0;
    private int _player1Phase = 1;
    private int _player2Point = 0;
    private int _player2Phase = 1;
    private int _p1SelectBeer = 0;
    private int _p2SelectBeer = 0;
    private int _p1SelectCup = 0;
    private int _p2SelectCup = 0;

    public void SelectBeer(int playerID, int beerID)
    {
        if (playerID == 1) _p1SelectBeer = beerID;
        else _p2SelectBeer = beerID;
    }
    public void SelectCup(int playerID, int cupID)
    {
        if (playerID == 1) _p1SelectCup = cupID;
        else _p2SelectCup = cupID;
    }

    public int GetSelectBeer(int playerID)
    {
        if (playerID == 1) return _p1SelectBeer;
        else return _p2SelectBeer;
    }

    public int GetSelectCup(int playerID)
    {
        if (playerID == 1) return _p1SelectCup;
        else return _p2SelectCup;
    }


    public int GetCurrentCustomerLeft() {  return _currentCustomerLeft; }
    public int GetPlayer1Phase() {  return _player1Phase; }
    public int GetPlayer2Phase() { return _player2Phase; }
    public int GetPlayerPoint(int playerID)
    {
        if (playerID == 1) return _player1Point;
        else return _player2Point;
    }
    public void ChangePhase(int playerID, int phaseID)
    {
        if (playerID == 1) { _player1Phase = phaseID; }
        else { _player2Phase = phaseID; }
        BattleUI.PhaseUIChange(playerID);
    }
    public void NextPhase(int playerID)
    {
        if (playerID == 1) 
        {
            if (_player1Phase != 4) _player1Phase++;
        }
        else 
        {
            if (_player2Phase != 4) _player2Phase++;
        }
        BattleUI.PhaseUIChange(playerID);
    }
    public void GetPoint(int playerID)
    {
        if (playerID == 1)
        {
            _player1Point++;

            BattleUI.Player1GetPoint(_player1Point);

            Player1RoundEndUI.SetActive(true);

            if (_player1Point == 4) ; //TODO: call player1 win

        }
        else
        {
            _player2Point++;

            BattleUI.Player2GetPoint(_player2Point);

            Player2RoundEndUI.SetActive(true);

            if (_player2Point == 4) ; //TODO: call player2 win
        }

        StartCoroutine(NextRoundWaitTime());

    }

    public void NextRound()
    {
        requestGenerator.NewRequest();
        _currentCustomerLeft--;

        _player1Phase = 1;
        _player2Phase = 1;
        _p1SelectBeer = 0;
        _p2SelectBeer = 0;
        _p1SelectCup = 0;
        _p2SelectCup = 0;

        BattleUI.RoundInitial();


        if (_currentCustomerLeft <= 0)
        {
            //TODO: game end
        }

    }

    private void Start()
    {
        requestGenerator.NewRequest();
    }

    IEnumerator NextRoundWaitTime()
    {
        yield return new WaitForSeconds(RoundWaitTime);
        NextRound();
    }


}
