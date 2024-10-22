using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuayQuat : MonoBehaviour
{
    public Vector3 moveDirection;
    private bool isRotating;
    private float rorateSpeed = 20f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 P = transform.position;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            isRotating = true;
       
            rorateSpeed += 150f;

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            isRotating = false;
        
        }
      


        if (isRotating)
        {
            transform.Rotate(Vector3.forward * rorateSpeed * Time.deltaTime);
        }

    }
}
