using NUnit.Framework;
using UnityEngine;

public class BubbleSoundController : MonoBehaviour
{
    public CupHandler Cup;
    private bool HasBubble = false; 
    public AudioSource bubbleAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if (Cup.GetData().curBubble > 0)
        {
            if (!bubbleAudioSource.isPlaying)
            {
                bubbleAudioSource.Play();
            }
            HasBubble = true;
        }
        else if (Cup.GetData().curBubble == 0 && HasBubble)
        {
            bubbleAudioSource.Stop();
            HasBubble = false;
        }
    }
}
