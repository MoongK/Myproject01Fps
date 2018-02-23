using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShooterMove : MonoBehaviour {

    float mover;
    float speed;

    float xx, yy, zz;
    GameObject RightWall;
    GameObject LeftWall;

    Vector3 RightEnd, LeftEnd; // ShooterMove가 이동 가능한 양 끝점


    void Start () {
        transform.position = new Vector3(0f, 0.5f, -21.78f);

        RightWall = GameObject.Find("RightWall");
        LeftWall = GameObject.Find("LeftWall");

        RightEnd = new Vector3(RightWall.transform.position.x - 4f, RightWall.transform.position.y,RightWall.transform.position.z);
        LeftEnd = new Vector3(LeftWall.transform.position.x + 4f, LeftWall.transform.position.y, LeftWall.transform.position.z);
    }

    void Update () {
        mover = Input.GetAxisRaw("Horizontal");
        speed = 50f * mover * Time.deltaTime;

        xx = transform.position.x;
        yy = transform.position.y;
        zz = transform.position.z;


        if(transform.position.x < LeftEnd.x)
        {
            if(mover >= 0)
                transform.position = new Vector3(xx + speed, yy, zz);
        }
        else if(transform.position.x > RightEnd.x)
        {
            if(mover <= 0)
                transform.position = new Vector3(xx + speed, yy, zz);
        }
        else
            transform.position = new Vector3(xx + speed, yy, zz);



        if(Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);


    }

}