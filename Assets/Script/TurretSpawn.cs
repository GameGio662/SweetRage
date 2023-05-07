using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField] GameObject Turret1, Turret2, Turret3;
    GameObject turretType;
    int type;


    void Start()
    {
        type = Random.Range(0, 3);
        TurretType(type);
    }


    void Update()
    {
        SelectTurret();
    }

    public void TurretType(int n)
    {
        switch (n)
        {
            case 0:
                turretType = Turret1;
                break;
            case 1:
                turretType = Turret2;
                break;
            case 2:
                turretType = Turret3;
                break;
        }
    }


    void SelectTurret()
    {
        var _turret = Instantiate(turretType);
        _turret.transform.position = transform.position;
        gameObject.SetActive(false);
    }
}
