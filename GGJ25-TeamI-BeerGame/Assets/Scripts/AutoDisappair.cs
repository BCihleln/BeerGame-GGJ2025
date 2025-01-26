using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AutoDisappair : MonoBehaviour
{
    [SerializeField] float disappairTime = 1f;
    [SerializeField] UnityEvent OnTimeUp;

    private void OnEnable()
    {
        StartCoroutine(StartTime());
    }

    IEnumerator StartTime()
    {
        yield return new WaitForSeconds(disappairTime);
        if (OnTimeUp != null) OnTimeUp.Invoke();

    }


}
