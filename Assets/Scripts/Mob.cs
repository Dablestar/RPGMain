using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    NavMeshAgent nav = new NavMeshAgent();
    Vector3 vEnd;
    Vector3 vDir;
    float fSpeed = 5.0f;
    float rSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    bool MousePick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100))
        {
            if (!hit.collider.tag.Contains("Terrain"))
                return false;


            //마우스 클릭 지점
            vEnd = hit.point;
            //방향벡터(회전또는 기타 각도계산에 사용)
            vDir = vEnd - transform.position;
            /*vDir값이 1로 계산되어 있는경우
            vDir.Normalize();
            vDir.normalized;*/



            return true;
        }



        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePick();
        }
        if (transform.position != vEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, vEnd, fSpeed * Time.deltaTime);
        }
        Quaternion location = Quaternion.LookRotation(vDir);

        transform.rotation = Quaternion.Slerp(transform.rotation, location, rSpeed * Time.deltaTime);

    }
}