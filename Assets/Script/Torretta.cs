using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Torretta : MonoBehaviour
{
    WaveManager WM;

    float timer, typeTimer;
    [SerializeField] bool normal, mitra, ice;
    [SerializeField] GameObject Ball, IceBall;
    GameObject Proiettile;
    [SerializeField] Transform Canna;


    public Transform target;
    public float range = 10f;

    GameManager GM;


    void Start()
    {
        WM = FindAnyObjectByType<WaveManager>();
        GM = FindAnyObjectByType<GameManager>();
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemytype = GameObject.FindGameObjectsWithTag("Enemy");
        float distanzaMinima = Mathf.Infinity;
        GameObject enemiVicino = null;
        foreach (GameObject enemy in enemytype)
        {
            float distanceEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceEnemy < distanzaMinima)
            {
                distanzaMinima = distanceEnemy;
                enemiVicino = enemy;

            }
        }

        if (enemiVicino != null && distanzaMinima <= range)
        {
            target = enemiVicino.transform;
        }
    }


    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            if (normal == true)
                Normal();
            if (mitra == true)
                Mitra();
            if (ice == true)
                Ice();

            Shoot();

            if (target == null)
                return;

            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, 25 * Time.deltaTime).eulerAngles;
            transform.rotation = Quaternion.Euler(0, rotation.y, 0);
        }
          
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    void Normal()
    {
        typeTimer = 1.5f;
        Proiettile = Ball;
    }

    void Mitra()
    {
        typeTimer = 0.5f;
        Proiettile = Ball;
    }

    void Ice()
    {
        typeTimer = 2;
        Proiettile = IceBall;
    }


    bool set;
    void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= typeTimer && WM.start == true && set == true)
        {
            var _proiettile = Instantiate(Proiettile, Canna.position, Canna.rotation);
            Bullet bullet = _proiettile.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Seek(target);

            timer = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BaseTurret")
        {
            set = true;
            Fermo = true;
        }
    }

    /////////////////////////
    Vector3 mousePosition;
    bool Fermo;
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (Fermo == false)
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
