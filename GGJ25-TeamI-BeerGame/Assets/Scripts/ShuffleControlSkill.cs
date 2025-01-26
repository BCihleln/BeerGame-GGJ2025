using UnityEngine;

public class ShuffleControlSkill : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public KeyCode P1SkillBtn = KeyCode.C;
    public KeyCode P2SkillBtn = KeyCode.Period;
    public KeyCode P2LeftBtn = KeyCode.LeftArrow;
    public KeyCode P2RightBtn = KeyCode.RightArrow;
    public KeyCode P2PourBtn = KeyCode.UpArrow;
    public KeyCode P1LeftBtn = KeyCode.A;
    public KeyCode P1RightBtn = KeyCode.D;
    public KeyCode P1PourBtn = KeyCode.W;

    public BeerHandler beerHandlerP1;
    public BeerHandler beerHandlerP2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(P1SkillBtn))
        {
            ShuffleControls(beerHandlerP2);
            Debug.Log("Player 2 controls shuffled");
        }
        else if (Input.GetKeyDown(P2SkillBtn))
        {
            ShuffleControls(beerHandlerP1);
            Debug.Log("Player 1 controls shuffled");
        }
    }

    void ShuffleControls(BeerHandler beerHandler)
    {
        KeyCode[] originalKeys = new KeyCode[] { beerHandler.LeftKey, beerHandler.RightKey, beerHandler.PourKey };
        KeyCode[] keys = (KeyCode[])originalKeys.Clone();
        System.Random rnd = new System.Random();
        
        do
        {
            for (int i = keys.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                KeyCode temp = keys[i];
                keys[i] = keys[j];
                keys[j] = temp;
            }
        } while (keys[0] == originalKeys[0] && keys[1] == originalKeys[1] && keys[2] == originalKeys[2]);

        beerHandler.LeftKey = keys[0];
        beerHandler.RightKey = keys[1];
        beerHandler.PourKey = keys[2];
    }
}
