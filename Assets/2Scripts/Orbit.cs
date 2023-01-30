using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public Transform center;
    public float orbitSpeed;
    Vector3 offSet;

    void Start()
    {
        center.position = target.position;
        offSet = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position + offSet;
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
        offSet = transform.position - target.position;
    }
}
