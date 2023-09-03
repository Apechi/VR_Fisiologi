using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRotationConstant : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private  float rotationSpeed = 1.0f;


    private void Update() {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
