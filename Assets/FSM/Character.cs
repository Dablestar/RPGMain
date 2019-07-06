using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMCustom;

namespace FSMCustom
{
	public enum eState
	{
		STATE_STAND = 0,
		STATE_MOVE,
		STATE_ATTACK,
		STATE_RUNAWAY,
	}

	public enum eEvent
	{
		EVENT_FINDTARGET = 0,
		EVENT_LOSTTARGET,
		EVENT_BEATTACKED,
		EVENT_HEALTHDRYUP,
		EVENT_STOPWALK,
		EVENT_PATROL
	}
}

public class Character : MonoBehaviour {

	const int STATE_COUNT = 4;
	int	radius;
	int	speed;
	
	CharacterState	action;
	List<CharacterState> arrayAction = new List<CharacterState>();
	FiniteStateMachine	stateMachine;

    public void Init(FiniteStateMachine fsm, int r, int spd)
    {
        arrayAction.Add(new StandAction(this));
        arrayAction.Add(new MoveAction(this));
        arrayAction.Add(new AttackAction(this));
        arrayAction.Add(new RunawayAction(this));

        action = arrayAction.Find(o => (o.state == eState.STATE_MOVE));

        stateMachine = fsm;
        radius = r;
        speed = spd;

    }
 
	public void process( Character target )
	{
		action.process( target );
	}
	
	public void setPosition( Vector3 pos )
	{
        this.transform.position = pos;
		//position.x = x; 
		//position.y = y; 
	}

	public Vector3 getPosition(){ return transform.position; }
	public int	getRadius(){ return radius; }
	public eState	getState()
	{
		if( stateMachine == null )
			return 0;
		return stateMachine.getCurrentStateID();
	}
	
	public void setTransition( eEvent nEvent )
	{
		stateMachine.stateTransition( nEvent );
		eState curState = stateMachine.getCurrentStateID();
		action = arrayAction.Find(o=>(o.state == curState ));
        Debug.Log(action);
	}

    public void MoveTo(Vector3 target)
    {
        Vector3 tmp = transform.position;

        Vector3 dir = target - tmp;
        dir.Normalize();
        tmp.x += dir.x * Time.deltaTime * speed;
        tmp.y += dir.y * Time.deltaTime * speed;
        tmp.z += dir.z * Time.deltaTime * speed;

        transform.position = tmp;
    }
}
