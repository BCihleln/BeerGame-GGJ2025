using UnityEngine;

public class ClinkingControl : MonoBehaviour
{
    public float selfDestoryTime = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, selfDestoryTime);
    }
}
