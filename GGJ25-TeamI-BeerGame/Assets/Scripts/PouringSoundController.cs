//Used to control a cup's pouring sound
using NUnit.Framework;
using UnityEngine;

public class PouringSoundController : MonoBehaviour
{
    public CupHandler Cup;
    public AudioSource pouringSound; // AudioSource for pouring sound
    private bool IsPouring = false;

    void Update()
    {
        IsPouring = Cup.GetPouringStatus();
        attemptToPlaySound();
    }
    void attemptToPlaySound()
    {
        if (IsPouring)
        {
            if (!pouringSound.isPlaying)
            {
                pouringSound.Play();
            }
        }
        else
        {
            pouringSound.Stop();
        }
    }
}
