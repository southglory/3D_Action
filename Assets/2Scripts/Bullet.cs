using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool isRock;

    private void Start()
    {
        Destroy(gameObject, 15);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isRock && collision.gameObject.tag == "Floor" && collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject, 1f);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "EnemyBullet" && other.gameObject.tag != "Floor" && other.gameObject.tag != "Item" && other.gameObject.tag != "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
