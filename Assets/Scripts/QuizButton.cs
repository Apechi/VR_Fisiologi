using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizButton : MonoBehaviour
{
    [SerializeField] private float gazeDuration = 2f;
    private bool isGazed;
    private float timer;
    public Button btn;


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
        if (btn.onClick != null)
        {
            btn.onClick.Invoke();
        }

        timer = 0f;
        gazeload.fillAmount = 0;
    }

}
