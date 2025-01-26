using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RequestGenerator : MonoBehaviour
{
    [SerializeField] Text perText;
    public GameObject requestCup;
    public GameObject customer;
    public List<Sprite> spriteList0 = new List<Sprite>();
    public List<Sprite> spriteList1 = new List<Sprite>();
    public List<Sprite> spriteList2 = new List<Sprite>();
    public List<Sprite> customerList = new List<Sprite>();
    public TMP_Text testingText;

    private int _currentBeer = 0;
    private int _currentCup = 0;
    private float _currentPercent = 0;

    public int GetCurrentBeer()
    {
        return _currentBeer;
    }

    public int GetCurrentCup()
    {
        return _currentCup;
    }
    public float GetCurrentPercent()
    {
        return _currentPercent;
    }

    //private void Start() {
    //    requestCup.GetComponent<SpriteRenderer>().sprite = null;
    //}

    public void NewRequest()
    {
        customer.GetComponent<SpriteRenderer>().sprite = customerList[Random.Range(0,2)];
        int drinkPick = Random.Range(0, 3);
        int cupPick = Random.Range(0, 3);
        float secondPick = 0;
        switch (drinkPick)
        {
            case 0:
                secondPick = Random.Range(0.4f, 0.8f); 
                requestCup.GetComponent<SpriteRenderer>().sprite = spriteList0[cupPick];
                break;
            case 1:
                secondPick = Random.Range(0.3f, 0.6f);
                requestCup.GetComponent<SpriteRenderer>().sprite = spriteList1[cupPick];
                break;
            case 2:
                secondPick = Random.Range(0.2f, 0.65f);
                requestCup.GetComponent<SpriteRenderer>().sprite = spriteList2[cupPick];
                break;
        }

        perText.text = (secondPick * 100).ToString("0") + "%";

        _currentBeer = drinkPick;
        _currentCup = cupPick;
        _currentPercent = secondPick;
    }
}
