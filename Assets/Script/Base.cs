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


    float up = 0.5f;
    int setCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turret" && setCount < 3)
        {
            other.transform.position = transform.position + Vector3.up * up;
            up += 1f;
            setCount++;

            if(setCount == 3)
            {
                col.enabled = false;
            }
        }
    }
}
