using System.Collections;
using UnityEngine;

public class ClinkingControl : MonoBehaviour
{
    public float selfDestoryTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(selfDestoryTime);

        gameObject.SetActive(false);
    }

}
