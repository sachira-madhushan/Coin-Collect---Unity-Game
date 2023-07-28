using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoler : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float cameraY;
    void Start()
    {
        
    }

  
    void LateUpdate()
    {
        if(!(player.transform.position.y< -1.085714f))
        {
            transform.position =new Vector3(0,player.transform.position.y+cameraY,-10f);

        }
    }
}
