﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 vEnd = Vector3.zero;
    Vector3 vDir = Vector3.zero;
    float fSpeed = 2.0f;

    public override void InitAwake()
    {
        base.InitAwake();
        Debug.Log("Player InitAwake()");
    }
    public override void InitStart()
    {
        base.InitStart();
        Debug.Log("Player InitStart()");
    }
    public override void UpdateDo()
    {
        base.UpdateDo();
        if (Input.GetMouseButtonDown(0))
        {
            if (Utility.CustomRay(ref out vEnd))
            {
                Nav.destination = vEnd;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
