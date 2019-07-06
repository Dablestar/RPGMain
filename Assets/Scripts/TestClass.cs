using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : Singleton<TestClass>
{
    public void Something()
    {
        Debug.Log("asdf");
    }
}
