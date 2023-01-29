using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range};
    public Type type;
    public int damage;
    public float rate;
    public int maxAmmo;
    public int curAmmo;


    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    public Transform bulletPos; //프리팹 생성할 위치
    public GameObject bullet;   //프리팹 저장할 변수
    public Transform bulletCasePos; //프리팹 생성할 위치
    public GameObject bulletCase;   //프리팹 저장할 변수

    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
        else if (type == Type.Range && curAmmo > 0)
        {
            curAmmo--;
            StartCoroutine("Shot");
        }
    }
    
    IEnumerator Swing()
    {
        //1
        yield return new WaitForSeconds(0.1f); // 0.1초 대기
        trailEffect.enabled = true;

        //2
        yield return new WaitForSeconds(0.3f); // 0.3초 대기
        meleeArea.enabled = true;
        
        //3
        yield return new WaitForSeconds(0.1f); // 0.1초 대기
        trailEffect.enabled = false;
        meleeArea.enabled = false;
    }

    IEnumerator Shot()
    {
        //#1. 총알 발사
        GameObject instantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = instantBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * 50;

        yield return null;//한 프레임 쉬기.
        //#2. 탄피 배출
        GameObject instantCase = Instantiate(bulletCase, bulletCasePos.position, bulletCasePos.rotation);
        Rigidbody caseRigid = instantCase.GetComponent<Rigidbody>();
        Vector3 caseVec = bulletCasePos.forward * Random.Range(-3, -2) + Vector3.up * Random.Range(2, 3);
        caseRigid.AddForce(caseVec, ForceMode.Impulse);
        caseRigid.AddTorque(Vector3.up * 10, ForceMode.Impulse);

    }

    // Use() 메인루틴 -> Swing() 서브루틴 -> Use() 메인루틴
    // Use() 메인루틴 + Swing() 코루틴 (Co-Op)
}
