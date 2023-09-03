using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonGaze : MonoBehaviour
{
    // Start is called before the first frame update
    public float gazeDuration = 3f;
    private bool isGazed;
    private float timer;

    public Button btnBack;

    // Start is called before the first frame update
    void Start()
    {
        btnBack.onClick.AddListener(OnClick);
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

        }
        
    }

    public void OnPointerEnter() {
        isGazed = true;
        timer = 0f;

    }

    public void OnPointerExit() {
        isGazed = false;
        timer = 0f;
    }

    private void OnGazeComplete()
    {
        btnBack.onClick.Invoke();
        timer = 0f;
    }


    public void OnClick() {
        
        Application.Quit();
    }
}
