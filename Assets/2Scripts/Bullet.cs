using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        Destroy(gameObject, 6);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject, 1f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        if (other.gameObject.tag != "Item" && other.gameObject.tag != "Weapon")
        {
            Destroy(gameObject, 1);
        }
    }
}
