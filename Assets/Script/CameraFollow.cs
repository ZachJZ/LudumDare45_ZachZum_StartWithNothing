using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Variables
    public Transform player;
    public float smooth = 0.3f;
    public float height = 1;

    public Vector3 velocity = Vector3.zero;


    void Update()
    {
        Vector3 pos = new Vector3();

        pos.x = player.position.x;
        pos.z = player.position.z - 5f;
        pos.y = player.position.y + height;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

        //look down
        if (Input.GetKeyDown(KeyCode.S))
        {
            height += -2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            height += 2;
        }

        //look up
        if (Input.GetKeyDown(KeyCode.W))
        {
            height += 2;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            height += -2;
        }






    }
}
