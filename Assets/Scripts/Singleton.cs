﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : class, new()
{
    private static T inst = null;
    public Singleton()
    {

    }
    public static T instance
    {
        get
        {
            if (inst == null)
            {
                inst = new T();
            }
            return inst;


        }
    }
}
