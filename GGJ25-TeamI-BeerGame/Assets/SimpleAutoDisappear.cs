using UnityEngine;

public class SimpleAutoDisappear : MonoBehaviour
{
    [SerializeField,
    Tooltip("Seconds that this GameObject will disable it self")]
    float disableDelay = 2f;
    public UnityEngine.Events.UnityEvent onDisableEvent = null;
    void OnEnable()
    {
        Invoke(nameof(DisableSelf), disableDelay);
    }

    void DisableSelf()
    {
        this.gameObject.SetActive(false);
    }
    
    void OnDisable()
    {
        onDisableEvent?.Invoke();
    }
}
