using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public ParticleSystem MyEffect;
    GameObject Tg;

    private void Start()
    {
        Tg = GameObject.Find("Targeter");
    }

    private void OnCollisionEnter(Collision other)
    {
        var ef = Instantiate(MyEffect, transform.position, Quaternion.identity);

        Destroy(gameObject, 0f);
        Destroy(ef.gameObject, 2f);

    }

}
