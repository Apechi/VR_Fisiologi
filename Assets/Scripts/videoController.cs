using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoController : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public GameObject playButton;
    public GameObject pauseButton;
        

    private bool isPlaying;

    [SerializeField] private float gazeDuration = 2f;
    private bool isGazed;
    private float timer;
    public Image gazeload;

    private void Start()
    {
        videoPlayer.Pause();
        isPlaying = false;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    private void Update()
    {
        if (isGazed)
        {
            timer += Time.deltaTime;

            if (timer >= gazeDuration)
            {
                timer = gazeDuration;
                OnGazeComplete();
            }

            gazeload.fillAmount = Mathf.Clamp01(timer / gazeDuration);
        }
    }

    public void OnPointerEnter()
    {
        isGazed = true;
        timer = 0f;
    }

    public void OnPointerExit()
    {
        isGazed = false;
        gazeload.fillAmount = 0;
        timer = 0f;
    }

    public void OnGazeComplete()
{
    if (isGazed)
    {
        if (isPlaying)
        {
            PauseVideo();
        }
        else
        {
            PlayVideo();
        }

        isGazed = false;
    }
}


    private void PlayVideo()
    {
        isPlaying = true;
        videoPlayer.Play();
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    private void PauseVideo()
    {
        videoPlayer.Pause();
        
        isPlaying = false;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }
}
