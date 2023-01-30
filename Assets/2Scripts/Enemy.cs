using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponent<MeshRenderer>().material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage;
            Vector3 reactVec = transform.position- other.transform.position;

            StartCoroutine(OnDamage(reactVec, false));

            Debug.Log("Melee : " + curHealth);
        }
        else if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            curHealth -= bullet.damage;
            Vector3 reactVec = transform.position - other.transform.position;
            Destroy(other.gameObject);

            StartCoroutine(OnDamage(reactVec, false));

            Debug.Log($"Range : {curHealth}");
        }
    }

    public void HitByGrenade(Vector3 explosionPos)
    {
        curHealth -= 100;
        Vector3 reactVec = transform.position - explosionPos;
        StartCoroutine(OnDamage(reactVec, true));
    }

    IEnumerator OnDamage(Vector3 reactVec, bool isGrenade)
    {
        mat.color = new Color(1f, 0.5f, 0f, 1f); // 주황색

        reactVec = reactVec.normalized;
        reactVec += Vector3.up;
        if (isGrenade)
        {
            rigid.AddForce(reactVec * 5, ForceMode.Impulse); // 넉백
            rigid.AddTorque(reactVec * 15, ForceMode.Impulse);
        }
        else
        {
            rigid.AddForce(reactVec * 1, ForceMode.Impulse); // 넉백
        }
        
        yield return new WaitForSeconds(0.2f);


        if (curHealth > 0)
        {
            mat.color = new Color(1f, 1f, 1f, 1f); //원래대로
        }
        else
        {
            mat.color = Color.gray; // Dead 회색
            gameObject.layer = 14;

            Destroy(gameObject, 4);
        }
    }
}
