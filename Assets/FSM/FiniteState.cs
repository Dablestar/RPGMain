using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMCustom;

public class FiniteState
{
	public eState		stateID;
	public Dictionary< eEvent, eState > mapTransition = new Dictionary<eEvent, eState>();

	public FiniteState( eState state ) 
	{ 
		stateID = state;
	}
	public eState getStateID(){ return stateID; }

	public void addTransition( eEvent inputEvent, eState outputStateID )
	{
		mapTransition[inputEvent] = outputStateID;
	}

	public void deleteTransition( eEvent inputEvent )
	{
		mapTransition.Remove(inputEvent);
	}

	public eState outputState( eEvent inputEvent )//throw ( InvalidInputEventException* );
	{
		if( !mapTransition.ContainsKey(inputEvent) )
		{
            string str = string.Format("event = {0} state = {1}, ", inputEvent, stateID);
            Debug.LogFormat(str);
			Debug.LogError("inputEvent is not valid");
		}
		return mapTransition[inputEvent];
    }

    public int getCount()
	{
		return mapTransition.Count;
	}
}
