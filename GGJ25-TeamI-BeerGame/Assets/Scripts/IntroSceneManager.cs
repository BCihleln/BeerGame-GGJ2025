using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    private AudioSource musicSource1;
    private AudioSource musicSource2;
    public AudioClip musicClip1;
    public AudioClip musicClip2;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        AudioSource[] audioSources = GetComponents<AudioSource>();
        musicSource1 = audioSources[0];
        musicSource2 = audioSources[1];
        musicSource1.clip = musicClip1;
        musicSource1.loop = true;
        musicSource1.Play();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == 0)
            {
                musicSource2.clip = musicClip2;
                musicSource2.loop = true;
                musicSource2.Play();
                musicSource1.volume = 0.3f;
                SceneManager.LoadScene(1);
            }
        }
    }
}
