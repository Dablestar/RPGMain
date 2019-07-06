using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public Transform CharacterObject;
    public float camDistance = 3.0f;

    public float xSpeed = 220.0f;
    public float ySpeed = 100.0f;

    public float x = 0.0f;
    public float y = 0.0f;

    public float yMinLimit = 20f;
    public float yMaxLimit = 80f;

    private float ClampAngle(float angle, float min, float max)
    {
        if(angle < 360)
        {
            angle += 360;
        }else if(angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    
    void Start()
    {

        Vector3 angles = transform.eulerAngles;

        
        x = angles.y;

        y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {

        


        //카메라 위치 변화 계산

        Quaternion rotation = transform.rotation;



        Vector3 position = rotation * new Vector3(0, 0.9f, -camDistance) + CharacterObject.position + new Vector3(0.0f, 0, 0.0f);



        transform.position = position;

    }
}
