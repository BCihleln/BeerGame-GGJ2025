using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public  TMP_Text PageText; // TMP text object to display page content
    public  TMP_Text MyText; // TMP text object to display page number
    private int currentPageIndex = 0; // Track the current page
    private int PageCount = 3; // Total number of pages
    void Start()
    {
        UpdateMyText();
        UpdatePageText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPage();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousPage();
        }
    }

    public void NextPage()
    {
        if (currentPageIndex < PageCount - 1)
        {
            currentPageIndex++;
            UpdateMyText();
            UpdatePageText();
        } else {
            // TODO: Load the next scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePageText();
            UpdateMyText();
        }
    }
    private void UpdatePageText()
    {   
        PageText.text = "Page " + (currentPageIndex + 1).ToString() + " of 3";
    }
    private void UpdateMyText()
    {
        if(currentPageIndex == 0)
        {
            MyText.text = "There are seven customers in one game, each with their own needs. You need to meet their needs within the time limit.\n If the beer overflows the cup, you will have to start over.";
        }
        else if(currentPageIndex == 1)
        {
            MyText.text = "You must fill the beer above the baseline before serving it to the customer.\n The foam ratio must meet the customer's requirements, or it will be rejected.";
        }
        else if(currentPageIndex == 2)
        {
            MyText.text = "At the beginning of the game, you will choose the type of beer and the type of cup. If you choose incorrectly, you will have to fill the beer and start over.";
        }
    }
}
