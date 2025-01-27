using System.Collections;
using UnityEngine;

public class ClinkingControl : MonoBehaviour
{
    public float selfDestoryTime = 2.0f;

    void OnEnable()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(selfDestoryTime);

        gameObject.SetActive(false);
    }

}
