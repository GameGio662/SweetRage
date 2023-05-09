using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] GameObject Turret;
    [SerializeField] GameObject SetTurret;
    [HideInInspector] public bool Spawn;
    Collider col;

    WaveManager WM;


    void Start()
    {
        col = GetComponent<Collider>();
        WM = FindAnyObjectByType<WaveManager>();

       
    }


    void Update()
    {
        Debug.Log("set " + setCount);

    }


    float up = 0.5f;
    int setCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Turret" && setCount < WM.maxCount)
        {
            other.transform.position = transform.position + Vector3.up * up;
            up += 1f;
            setCount++;

            if (setCount == WM.maxCount)
            {
                col.enabled = false;
            }
        }
    }
}
