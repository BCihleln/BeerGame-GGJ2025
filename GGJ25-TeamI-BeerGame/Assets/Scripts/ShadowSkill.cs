using UnityEngine;

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
        offset = Random.Range(-10f, 10f);
        CreateFakeCup();
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
            MoveCup(0.5f);
        }
    }

    void CreateFakeCup()
    {
        fakeCupInstance = Instantiate(fakeCupPrefab, cup.transform.position, cup.transform.rotation);
        fakeCupInstance.GetComponent<CupHandler>().enabled = false; // Disable CupHandler to prevent interaction with beer
    }

    void CreateFakeCupP2()
    {
        if (fakeCupInstanceP2 != null)
        {
            Destroy(fakeCupInstanceP2);
        }
        fakeCupInstanceP2 = Instantiate(fakeCupPrefabP2, cupP2.transform.position, cupP2.transform.rotation);
        fakeCupInstanceP2.GetComponent<CupHandler>().enabled = false; // Disable CupHandler to prevent interaction with beer
        fakeCupInstanceP2.transform.position += new Vector3(Random.Range(-10f, 10f), 0, 0);
    }

    void MoveCup(float offset)
    {
        cup.transform.position += new Vector3(offset, 0, 0);
        fakeCupInstance.transform.position = cup.transform.position + new Vector3(Random.Range(-10f, 10f), 0, 0);
    }

    void MoveCupRandomly(CupHandler cup)
    {
        float randomOffset = Random.Range(-1f, 1f);
        cup.transform.position += new Vector3(randomOffset, 0, 0);
    }
}
