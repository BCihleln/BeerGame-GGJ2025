using UnityEngine;
using System.Collections;

public class ShadowSkill : MonoBehaviour
{
    public CupHandler cup;
    public CupHandler cupP2;
    public GameObject fakeCupPrefab;
    public GameObject fakeCupPrefabP2;
    private GameObject fakeCupInstance;
    private GameObject fakeCupInstanceP2;
    
    public KeyCode P1SkillBtn = KeyCode.C;
    public KeyCode P2SkillBtn = KeyCode.Period;

    private float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = Random.Range(-4f, 4f);
        // Do not create the fake cup for P1 at the start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(P1SkillBtn))
        {
            MoveCupRandomly(cupP2);
            CreateFakeCupP2();
        }
        else if (Input.GetKeyDown(P2SkillBtn))
        {
            MoveCupRandomly(cup);
            CreateFakeCup();
        }
    }

    void CreateFakeCup()
    {
        if (fakeCupInstance != null)
        {
            Destroy(fakeCupInstance);
        }
        fakeCupInstance = Instantiate(fakeCupPrefab, cup.transform.position, cup.transform.rotation);
        fakeCupInstance.GetComponent<CupHandler>().enabled = false; // Disable CupHandler to prevent interaction with beer
        fakeCupInstance.transform.position += new Vector3(Random.Range(-4f, 4f), 0, 0);
        StartCoroutine(RemoveFakeCupAfterDelay(fakeCupInstance, 4f));
    }

    void CreateFakeCupP2()
    {
        if (fakeCupInstanceP2 != null)
        {
            Destroy(fakeCupInstanceP2);
        }
        fakeCupInstanceP2 = Instantiate(fakeCupPrefabP2, cupP2.transform.position, cupP2.transform.rotation);
        fakeCupInstanceP2.GetComponent<CupHandler>().enabled = false; // Disable CupHandler to prevent interaction with beer
        fakeCupInstanceP2.transform.position += new Vector3(Random.Range(-4f, 4f), 0, 0);
        StartCoroutine(RemoveFakeCupAfterDelay(fakeCupInstanceP2, 4f));
    }

    IEnumerator RemoveFakeCupAfterDelay(GameObject fakeCup, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(fakeCup);
    }

    void MoveCup(float offset)
    {
        Vector3 newPosition = cup.transform.position + new Vector3(offset, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -6f, 6f); // Adjust the values based on your screen bounds
        cup.transform.position = newPosition;
        fakeCupInstance.transform.position = newPosition + new Vector3(Random.Range(-4f, 4f), 0, 0);
    }

    void MoveCupRandomly(CupHandler cup)
    {
        float randomOffset = Random.Range(-1f, 1f);
        Vector3 newPosition = cup.transform.position + new Vector3(randomOffset, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, -6f, 6f); // Adjust the values based on your screen bounds
        cup.transform.position = newPosition;
    }
}
