using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rect rc;
    public Rect rcOther;
    public GameObject mob;
    // Start is called before the first frame update
    void Start()
    {
        rc.x = transform.position.x - rc.width / 2;
        rc.y = transform.position.y - rc.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        rc.x = transform.position.x - rc.width / 2;
        rc.y = transform.position.y - rc.width / 2;

        if (rc.Overlaps(rcOther))
        {
            Debug.Log(mob.gameObject.name);
        }
    }
}
