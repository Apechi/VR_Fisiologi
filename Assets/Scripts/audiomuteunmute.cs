using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audiomuteunmute : MonoBehaviour
{
    [SerializeField] private float gazeDuration = 2f;
    private bool isGazed;
    private float timer;

    
    public AudioSource audio;
    public GameObject mute;
    public GameObject unmute;


    public Image gazeload;
   

    // Update is called once per frame
    void Update()
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

    public void OnPointerEnter() {
        isGazed = true;
        timer = 0f;

    }

    public void OnPointerExit() {
        isGazed = false;
        gazeload.fillAmount = 0;
        timer = 0f;
    }

    private void OnGazeComplete()
    {
        if (!audio.mute) {
            MuteAudio();
        } else {
            UnmuteAudio();
        }
        timer = 0f;
        gazeload.fillAmount = 0;
    }

    public void MuteAudio() {
        audio.mute = true;
        unmute.SetActive(true);
        mute.SetActive(false);
    }

    public void UnmuteAudio() {
        audio.mute = false;
        unmute.SetActive(false);
        mute.SetActive(true);
    }
}
