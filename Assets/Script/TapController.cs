using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    Base b;
    void Start()
    {
        b = FindAnyObjectByType<Base>();
    }

    void Update()
    {
       Tap();
    }


    void Tap()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1f))
            {
                if (hit.transform != null)
                {
                    if (hit.collider.tag == "BaseTurret")
                    {
                        b.Spawn = true;
                    }
                       
                }
            }
        }
    }
}
