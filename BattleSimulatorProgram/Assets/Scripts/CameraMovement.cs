using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private float scrollSpeed = 10f;

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position +=  new Vector3(moveSpeed * Input.GetAxis("Horizontal"), 0, moveSpeed * Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position +=  new Vector3(0, scrollSpeed * -Input.GetAxis("Mouse ScrollWheel"), 0);
        }
    }
}
