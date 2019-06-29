using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterP : MonoBehaviour
{
    public NavMeshAgent _navi;
    public Animator _ani;
    public Animator ani
    {
        get
        {
            if (_ani == null)
                _ani = GetComponent<Animator>();

            return _ani;
        }
    }
    public AniManager aniM;
    Vector3 vEnd = Vector3.zero;
    Vector3 vDir = Vector3.zero;
    float fSpeed = 5.0f;
    float rSpeed = 5.0f;

    
    // Start is called before the first frame update
    private void Awake()//인스턴스가 생성될때
    {
        InitAwake();
    }
    virtual public void InitAwake()
    {
        _navi = GetComponent<NavMeshAgent>();
    }
    void Start()//화면 렌더링되기 바로 전에
    {
        InitStart();
    }
    virtual public void InitStart()
    {
        transform.position = vEnd;
        aniM.InitAniManager(ani);
        aniM = new AniManager();
    }
    

    bool MousePick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if(Physics.Raycast(ray, out hit, 100))
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePick();
            if(MousePick().Equals(true))
            {
            }
            
        }
        if(transform.position != vEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, vEnd, fSpeed * Time.deltaTime);
        }
        

        //Vector3 newDir = Vector3.RotateTowards(transform.forward, vDir.normalized, rSpeed*Time.deltaTime, 0.0f);
        //transform.rotation = Quartenion.LookRotation(newDir);

        Quaternion location = Quaternion.LookRotation(vDir);

        transform.rotation = Quaternion.Slerp(transform.rotation, location , rSpeed * Time.deltaTime);

        Vector3 origin = transform.position;
        origin.x += transform.forward.x;
        origin.z += transform.forward.z;
        origin.y += 1.5f;
        Vector3 dir = origin;
        dir.y = -dir.y;

        RaycastHit[] hits = Physics.RaycastAll(origin, -Vector3.up);
        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.gameObject.name != "Terrain")
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }

        
    }
}
