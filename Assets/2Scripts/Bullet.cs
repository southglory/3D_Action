using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void Start()
    {
        Destroy(gameObject, 3);
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(gameObject, 3);
    //    //if (collision.gameObject.tag == "Floor")
    //    //{
            
    //    //}
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    Destroy(gameObject, 3);
    //    //if (other.gameObject.tag == "Wall")
    //    //{
            
    //    //}
    //}
}
