using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject Cam;
    Vector3 camPos;
    Vector3 camRot;

    void Start()
    {
        camPos.y = 2.5f;
        camPos.z = -10; 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Move(){
       if (Cam.transform.forward.x > 0){
           camPos.x += 1;
           Cam.transform.position = camPos;
       } else {
           camPos.x -= 1;
           Cam.transform.position = camPos;
       }
    }
}
