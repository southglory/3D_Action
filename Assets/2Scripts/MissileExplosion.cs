using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : MonoBehaviour
{
    public GameObject MeshObject;
    public GameObject throttleEffect;
    public GameObject ExplosionEffect;
    Rigidbody rigidBullet;

    bool exploded = false;

    // Update is called once per frame
    void Start()
    {
        MeshObject = transform.Find("Mesh Object").gameObject;
        throttleEffect = transform.Find("Effect").gameObject;
        ExplosionEffect = transform.Find("Sub Dust").gameObject;
        rigidBullet = transform.GetComponent<Rigidbody>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        if (other.gameObject.tag != "Item" && other.gameObject.tag != "Weapon")
        {
            rigidBullet.velocity = Vector3.zero;
            MeshObject.SetActive(false);
            throttleEffect.SetActive(false);
            ExplosionEffect.SetActive(true);
            exploded = false;
        }
    }

}
