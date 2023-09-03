using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TTSMateri : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audioSource;
    private Transform parentTransform;
    private bool hasStarted = false;

    private void Start() 
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        parentTransform = gameObject.transform.parent;
        audioSource.loop = false;
    }

    private void Update() 
    {
        if (parentTransform.localScale.x >= 1 && parentTransform.localScale.y >= 1 && parentTransform.localScale.z >= 1) 
        {
            if (!audioSource.isPlaying && !hasStarted) 
            {
                audioSource.clip = clip;
                audioSource.Play();
                hasStarted = true;
            }
        } else {
            if (audioSource.isPlaying) 
            {
                audioSource.Stop();
            }
            hasStarted = false;
        }
    }
}
