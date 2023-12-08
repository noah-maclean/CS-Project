using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;

    void FixedUpdate()
    {
        //makes the position of the camera equal to the x position of the player every frame
        this.transform.position = new Vector3(followObject.position.x, 0f, this.transform.position.z);
    }
}
