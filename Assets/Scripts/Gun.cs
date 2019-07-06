using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform user;

    public float distance = 3.0f;

    private float gunX;
    private float gunY;
    private float gunZ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gunX = user.position.x + 2.0f;
        gunY = user.position.y + 1.0f; ;
        gunZ = user.position.z;

        if (Input.GetMouseButton(1))
        {
            GunFire();
        }
    }
    public void GunFire()
    {

    }
}
