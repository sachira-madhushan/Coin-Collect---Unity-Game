using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    void Start()
    {
        this.transform.Rotate(0, 0, -90);
    }


    void Update()
    {
        if (this.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
