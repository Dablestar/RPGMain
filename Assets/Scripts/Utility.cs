using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    // Start is called before the first frame update
   public static bool CustomRay(out Vector3 vEnd)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100))
        {
            if (!hit.collider.tag.Contains("Terrain"))
                return false;


            Debug.Log(hit.collider.name);
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
}
