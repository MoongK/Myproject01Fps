using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour {

    GameObject p1;
    CharacterController con;
    float speed = 10f;
    float gravity = 9.8f;
    float moveSpeed;
    bool isJumping = false;

    Vector3 moveDir = Vector3.zero;


    void Start () {
        p1 = gameObject;
        con =  p1.GetComponent<CharacterController>();
	}

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float jump = 2f;

        moveDir = new Vector3(h, 0f, v).normalized;
        moveDir = transform.TransformDirection(moveDir);

        StartCoroutine(Mover(jump));
    }

    IEnumerator Mover(float jump)
    {
        if (Input.GetKeyDown(KeyCode.Space) && con.isGrounded)
        {
            while (transform.position.y < jump)
            {
                con.Move(Vector3.up * 0.25f); // 점프
                yield return null;
            }
        }

        moveSpeed = speed * Time.deltaTime; // 이동속도
        moveDir.y -= gravity * 3 * Time.deltaTime; // 낙하속도
        con.Move(moveDir * moveSpeed); // 움직임

        yield return null;
    }

}
