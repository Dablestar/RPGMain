using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AniManager
{

    Dictionary<eAniIndex, AniAction> aniActions = new Dictionary<eAniIndex, AniAction>();
    Dictionary<string, eAniIndex> aniNames = new Dictionary<string, eAniIndex>();

    Animator ani;
    AniAction curAction = null;
    string nextAni = "";
    string curAni = "";


    enum eAniIndex
    {
        IDLE,
        WALK
    }



    void AddAction()
    {
        aniActions.Add(eAniIndex.IDLE, new Idle());
        aniActions.Add(eAniIndex.WALK, new Walk());
    }

    void AddIndex()
    {
        aniNames.Add("idle", eAniIndex.IDLE);
        aniNames.Add("walk", eAniIndex.WALK);
    }

    public void SetAction(string strNext)
    {
        nextAni = strNext;
        if(curAni != nextAni)
        {
            setAnimation(nextAni);
            curAni = nextAni;
        }
    }
    
    public void setAnimation(string strName)
    {
        eAniIndex nIndex = eAniIndex.IDLE;

        nIndex = aniNames[nextAni];
        ani.SetInteger("iAniINdex", (int)nIndex);
        curAction = aniActions[(eAniIndex)nIndex];
    }

    public void InitAniManager(Animator _ani)
    {
        ani = _ani;
        AddAction();   
        AddIndex();
        curAction = aniActions[eAniIndex.IDLE];

        AnimatorClipInfo[] clipInfo = ani.GetCurrentAnimatorClipInfo(0);
        curAni = clipInfo[0].clip.name;
        nextAni = curAni;
    }    

    

}

public class AniAction
{
    public virtual void Update()
    {

    }
}
public class Walk : AniAction
{
    public override void Update()
    {

    }
}

public class Idle : AniAction
{
    public override void Update()
    {

    }
}

