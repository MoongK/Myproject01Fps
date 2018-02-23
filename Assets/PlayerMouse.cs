using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour {

    public float mouseSpeed;
    float rotationX;
    float rotationY;

    private void Start()
    {
        mouseSpeed = 100f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        float x = Input.GetAxisRaw("Mouse X"); // 몸체
        float y = Input.GetAxisRaw("Mouse Y"); // 마우스
        float mouseMove = mouseSpeed * Time.deltaTime;

        //rotationX += x * mouseMove;
        //rotationY += y * mouseMove;

        //if (rotationY > 90f)
        //    rotationY = 90f;
        //if (rotationY < -90f)
        //    rotationY = -90f;

        //transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.left); // 위아래
        //transform.localRotation = Quaternion.AngleAxis(rotationX * mouseMove, transform.parent.up); 좌우

        rotationX += x * mouseSpeed * Time.deltaTime;
        rotationY += y * mouseSpeed * Time.deltaTime;


        if (rotationY > 90f)
            rotationY = 90f;
        if (rotationY < -90f)
            rotationY = -90f;

        transform.localRotation = Quaternion.AngleAxis(rotationY, Vector3.left);
        transform.localRotation = Quaternion.AngleAxis(rotationX, transform.transform.up);



        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
        if(Input.GetKeyDown(KeyCode.Mouse1))
            Cursor.lockState = CursorLockMode.Locked;


    }
}
