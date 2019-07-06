using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    List<Mob> mobList = new List<Mob>();

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Mob");
        for(int i = 0; i < objs.Length; i++)
        {
            mobList.Add(objs[i].GetComponent<Mob>());
        }
    }
    private void Update()
    {
        
    }
}
