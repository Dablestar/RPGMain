using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    NavMeshAgent _nav;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        
    }
    virtual public void Init()
    {

    }
    virtual public void onEnable()
    {
        onEnable();
    }
    virtual public void onDisable()
    {
        onDisable();
    }
    virtual public void InitAwake()
    {
        
    }
    virtual public void InitStart()
    {

    }
    virtual public void UpdateDo()
    {
  
    }
    public bool MousePick()
    {


    }
    public NavMeshAgent Nav()
    {
            if (_nav == null)
            {
                _nav.GetComponent<NavMeshAgent>();
                return Nav;
            }
    }

}
