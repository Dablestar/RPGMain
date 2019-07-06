using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMCustom;

class InvalidCurrentStateException
{
	int	currentStateID;
	public InvalidCurrentStateException( int curStateID )
	{
	}
}

class InvalidInputEventException
{
	int	inputEvent;
	public	InvalidInputEventException( int nEvent )
	{

	}
}

public class FiniteStateMachine
{
    Dictionary<eState, FiniteState> mapState = new Dictionary<eState, FiniteState>();
	FiniteState	currentState;
	public FiniteStateMachine(){}

	public void addStateTransition( eState stateID, eEvent inputEvent, eState outputStateID )
	{
        FiniteState state = null;
		if( true == mapState.ContainsKey(stateID) )
		{
			state = mapState[stateID];
		}
		// 리스트에 상태가 없다면 새로 생성한다..
		else if( false == mapState.ContainsKey(stateID))
		{
			state = new FiniteState(stateID);
			mapState.Add(state.getStateID(),state );
		}

		if( null != state )
			state.addTransition( inputEvent, outputStateID );
    }

    void deleteTransition( eState stateID, eEvent inputEvent )
	{
        if (true == mapState.ContainsKey(stateID))
        {
            mapState[stateID].deleteTransition(inputEvent);
            mapState.Remove(stateID);
        }
    }

	// 현재 상태에 이벤트로 다음 상태를 돌려준다.
	public eState	getOutputState( eEvent inputEvent )
	{
		eState nCurstateId = getCurrentStateID();
        FiniteState state = mapState[nCurstateId];
		return state.outputState(inputEvent);
	}
	
	public void setCurrentState(eState stateID )
	{
        currentState = mapState[stateID];
    }

	public eState	getCurrentStateID()
	{
		if( currentState == null )
			Debug.LogError("currentState is nullreference");
		return currentState.getStateID();
	}

    public void show()
    {
        foreach (KeyValuePair<eState, FiniteState> one in mapState)
        {
            string str = one.Key.ToString() + "\n";

            foreach( KeyValuePair<eEvent, eState> o in one.Value.mapTransition )
            {
                str += "          " + o.Key.ToString() + " " + o.Value.ToString() + "\n";
            }

            Debug.Log(str);
        }
    }

	public void stateTransition( eEvent nEvent )
	{
        eState outputState = currentState.outputState( nEvent );
        currentState = mapState[outputState];
    }
	
}
