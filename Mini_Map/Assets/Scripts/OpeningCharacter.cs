using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCharacter : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("CamPath")
                       , "time", 20.0f
                       , "easetype", iTween.EaseType.easeInCubic
                       , "looktarget", target
                       , "looktime", 0.1f
                       , "oncomplete", "MoveEnd"
                       ));
    }

    // Update is called once per frame


    //자동패치시 사용함
       IEnumerator Test()
        {
         yield return null;
         yield return StartCoroutine(Test1());
         yield return StartCoroutine(Test1());
         yield return StartCoroutine(Test1());
         yield return StartCoroutine(Test1());
         Debug.Log("Test");
        }
    
    IEnumerator Test1()
     {
         yield return null;
         StopCoroutine(Test());
    }/**/
    void Update()
    {
        
    }
}
