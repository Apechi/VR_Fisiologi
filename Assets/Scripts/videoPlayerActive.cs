using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class videoPlayerActive : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float gazeDuration = 2f;
    private bool isGazed;
    private float timer;
    private Vector3 disableScale = new Vector3(0, 0, 0);
    private Vector3 enableScale = new Vector3(1, 1, 1);
    public GameObject parentObject;
    public GameObject otherObject;

    public Image gazeload;
   

    // Start is called before the first frame update
    void Start()
    {
    
    }

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
        parentObject.transform.localScale = disableScale;
       
       if (otherObject != null) {
        otherObject.transform.localScale = enableScale;
       }

        timer = 0f;
        gazeload.fillAmount = 0;
    }
}
