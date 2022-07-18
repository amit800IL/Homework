using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Transform camera;
    
    private void Update()
    {
        camera.LookAt(transform);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 300); 
  
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 300);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 300);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 300);
        }

        if (Input.GetKey(KeyCode.P))
        {
            Vector3 scale = transform.localScale;
            scale *= 1.05f;
            transform.localScale = scale;
        }

        if (Input.GetKey(KeyCode.M))
        {
            Vector3 scale = transform.localScale;
            scale /= 1.05f;
            transform.localScale = scale;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * 300);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * 300);    
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 300);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * 300);
        }
    }

    
}
