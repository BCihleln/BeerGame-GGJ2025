using UnityEngine;

public class GameRoundManager : MonoBehaviour
{
    [SerializeField] BattleUIControl BattleUI;

    private int _currentCustomerLeft = 7;
    private int _player1Point = 0;
    private int _player1Phase = 1;
    private int _player2Point = 0;
    private int _player2Phase = 1;

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
            if (_player1Phase != 3) _player1Phase++;
        }
        else 
        {
            if (_player2Phase != 3) _player2Phase++;
        }
        BattleUI.PhaseUIChange(playerID);
    }
    public void GetPoint(int playerID)
    {
        if (playerID == 1)
        {
            _player1Point++;

            BattleUI.Player1GetPoint(_player1Point);

            if (_player1Point == 4) ; //call player1 win

        }
        else
        {
            _player2Point++;

            BattleUI.Player2GetPoint(_player2Point);

            if (_player2Point == 4) ; //call player2 win
        }
    }

    public void NextRound()
    {
        _currentCustomerLeft--;

        BattleUI.RoundInitial();

        if (_currentCustomerLeft == 0)
        {
            //game end
        }


    }


}
