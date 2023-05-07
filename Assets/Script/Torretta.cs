using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torretta : MonoBehaviour
{


    float timer, typeTimer;
    [SerializeField] bool normal, mitra, ice;
    [SerializeField] GameObject Ball, IceBall;
    GameObject Proiettile;
    [SerializeField] Transform Canna;

    void Start()
    {
    }

    void Update()
    {
        if (normal == true)
            Normal();
        if (mitra == true)
            Mitra();
        if (ice == true)
            Ice();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BaseTurret")
        {
            transform.position = other.transform.position + Vector3.up * 1;
            Fermo = true;
        }
        //if (other.gameObject.tag == "Turret")
        //{
        //    transform.position = other.transform.position + Vector3.up * 1;
        //    Fermo = true;
        //}


    }




    void Normal()
    {
        typeTimer = 4;
        Shoot();
        Proiettile = Ball;
    }

    void Mitra()
    {
        typeTimer = 1f;
        Shoot();
        Proiettile = Ball;
    }

    void Ice()
    {
        typeTimer = 5;
        Shoot();
        Proiettile = IceBall;
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= typeTimer)
        {
            var _proiettile = Instantiate(Proiettile, Canna.position, Canna.rotation);
            _proiettile.GetComponent<Rigidbody>().AddForce((Canna.forward * 20), ForceMode.Impulse);
            timer = 0;
        }
    }


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
