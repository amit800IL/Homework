using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] Camera cam;
    [SerializeField] Transform orientation;
    float mouseX;
    float mouseY;

    float multiplayer = 0.1f;

    float Xrotation;
    float Yrotation;
    float Zrotation;

    private void Start()
    {

        cam= GetComponentInChildren<Camera>();

       
    }

    private void Update()
    {
        myInput();

        cam.transform.localRotation = Quaternion.Euler(Xrotation, Yrotation, Zrotation);
        orientation.transform.rotation = Quaternion.Euler(0, Yrotation , 0);
    }

    void myInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;


        Yrotation += mouseX * sensX * multiplayer;
        Xrotation -= mouseY * sensY * multiplayer;

        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
    }
}
