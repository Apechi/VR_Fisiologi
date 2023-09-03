using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoPlayerObjectActive : MonoBehaviour
{
    public GameObject myObject;
    public GameObject background;
    public Material bgMaterial;
    private Color originalColor;


    void Start() {
        originalColor = bgMaterial.color;    
    }
    // Update is called once per frame
    void Update()
    {
        if (myObject.activeSelf) {
            bgMaterial.color = Color.gray;
        } else {
            bgMaterial.color = originalColor;
        }
        
    }
}
