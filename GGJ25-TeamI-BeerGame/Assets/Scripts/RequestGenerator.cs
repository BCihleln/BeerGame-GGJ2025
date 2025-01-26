using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RequestGenerator : MonoBehaviour
{
    public GameObject requestCup;
    public GameObject customer;
    public List<Sprite> spriteList0 = new List<Sprite>();
    public List<Sprite> spriteList1 = new List<Sprite>();
    public List<Sprite> spriteList2 = new List<Sprite>();
    public List<Sprite> customerList = new List<Sprite>();
    public TMP_Text testingText;

    private void Start() {
        requestCup.GetComponent<SpriteRenderer>().sprite = null;
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            testingText.text = NewRequest().ToString();
        }
    }

    public float NewRequest()
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
        return secondPick;
    }
}
