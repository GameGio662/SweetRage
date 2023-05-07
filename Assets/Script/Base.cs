using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] GameObject Turret;
    [SerializeField] GameObject SetTurret;
    [HideInInspector] public bool Spawn;
    Collider col;


    void Start()
    {
        col = GetComponent<Collider>();
    }


    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Turret")
        {
            col.enabled = false;
        }
    }
}
