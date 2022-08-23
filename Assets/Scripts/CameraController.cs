using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ref: https://www.youtube.com/watch?v=_QajrabyTJc
    //from project : Brackeys_FPS_Movement_unity2020    
    
    /*
     ** Mouse sensitivity settings
     */
    public float mouseSensitivity = 1200f;
    float xSensitivity = 3f;
    float ySensitivity = 3f;

    //variable to store the up/down rotation, and also to be able to limit it to 90°
    float xRotation = 0f;

    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY * xSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX * ySensitivity);
    }
}
