using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] GameObject Turret;
    [SerializeField] GameObject SetTurret;
    [HideInInspector] public bool Spawn;

    void Start()
    {

    }


    void Update()
    {
        Debug.Log(Spawn);
        SpawnerTurret();
    }


    void SpawnerTurret()
    {
        if (Spawn == true)
        {
            Instantiate(Turret, SetTurret.transform.position, Quaternion.identity);
        }
    }

}
