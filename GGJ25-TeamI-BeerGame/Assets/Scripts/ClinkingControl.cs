using UnityEngine;

public class ClinkingControl : MonoBehaviour
{
    public AudioSource clinkingAudioSource;
    public bool p1Win = false;
    public bool p2Win = false;

    public GameObject clinkingImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clinkingImage.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (p1Win){
            ShowImageAtP1();
            p1Win = false;
        }else if (p2Win)
        {
            ShowImageAtP2();
            p2Win = false;
        }
    }
    private void PlayClinkingSound(){
        if (!clinkingAudioSource.isPlaying){
            clinkingAudioSource.PlayOneShot(clinkingAudioSource.clip);
        }
    }
    private void ShowImageAtP1(){
        // Show image at player 1
        clinkingImage.transform.position = new Vector3(-4, 0, 0);
        clinkingImage.SetActive(true);
        PlayClinkingSound();
    }
    private void ShowImageAtP2(){
        // Show image at player 2
        clinkingImage.transform.position = new Vector3(4, 0, 0);
        clinkingImage.SetActive(true);
        PlayClinkingSound();
    }
    public void HideImage(){
        clinkingImage.SetActive(false);
    }
}
