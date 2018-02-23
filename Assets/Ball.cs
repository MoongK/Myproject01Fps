using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    GameObject shooter, tg;
    public float power;
    bool isShoot;


    void Start()
    {
        isShoot = false;
        shooter = GameObject.Find("Shooter");
        tg = GameObject.Find("Targeter");
        power = 1000f;
    }

    void Update () {

        if(tg.transform.childCount == 0)
        {
            Destroy(gameObject, 0f);
        }

        if (isShoot == false)
        {
            transform.position = shooter.transform.position + new Vector3(0f, 0f, 1.5f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0f, 1f) * power);
                isShoot = true;
            }

        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "DeadLine")
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = shooter.transform.position + new Vector3(0f, 0f, 1.5f);
            isShoot = false;
            //Destroy(gameObject, 0f);
        }
    }


}
