using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FSMCustom;

public class AIManager : MonoBehaviour
{
	FiniteStateMachine basic_fsm;

	List< Character > listCharacter = new List<Character>();
	Character myCharacter = null;
    public Character PLAYER
    {
        get
        {
            if (myCharacter == null)
            {
                GameObject obj = Instantiate((GameObject)Resources.Load("Player"));
                myCharacter = obj.AddComponent<Character>();
            }
            return myCharacter;
        }
    }

	void Awake()
	{
        PLAYER.Init(null, 0, 0);
        PLAYER.gameObject.name = "Player";
        PLAYER.setPosition(new Vector3(0, 0, 0));

		for( int i = 0 ; i < 10; i++ )
		{
			basic_fsm = new FiniteStateMachine();
			
			basic_fsm.addStateTransition( eState.STATE_STAND, eEvent.EVENT_FINDTARGET, eState.STATE_ATTACK );
			basic_fsm.addStateTransition( eState.STATE_STAND, eEvent.EVENT_BEATTACKED, eState.STATE_ATTACK );
			basic_fsm.addStateTransition( eState.STATE_STAND, eEvent.EVENT_PATROL, eState.STATE_MOVE );
			
			basic_fsm.addStateTransition( eState.STATE_MOVE, eEvent.EVENT_FINDTARGET, eState.STATE_ATTACK );
			basic_fsm.addStateTransition( eState.STATE_MOVE, eEvent.EVENT_STOPWALK, eState.STATE_STAND );
			
			basic_fsm.addStateTransition( eState.STATE_ATTACK, eEvent.EVENT_LOSTTARGET, eState.STATE_STAND );
			basic_fsm.addStateTransition( eState.STATE_ATTACK, eEvent.EVENT_HEALTHDRYUP, eState.STATE_RUNAWAY );
			
			basic_fsm.addStateTransition( eState.STATE_RUNAWAY, eEvent.EVENT_LOSTTARGET, eState.STATE_STAND );
            basic_fsm.setCurrentState( eState.STATE_MOVE );

            GameObject obj = Instantiate((GameObject)Resources.Load("Enemy"));
            obj.name = "enemy_" + i.ToString();

            Character enemy = obj.AddComponent<Character>();
            Vector3 pos = new Vector3(Random.Range(0, 20), 0, Random.Range(0, 20));

            //            enemy.Init( basic_fsm, 10 + Random.Range(0,10), 2 + Random.Range(0,3));
            enemy.Init(basic_fsm, 3, 2 + Random.Range(0, 3));
            enemy.setPosition( pos );

            Debug.Log(enemy.getPosition().ToString());
            listCharacter.Add( enemy );
 //           basic_fsm.show();
        }
	}

	void Start () 
	{
		//CustomRandom ran = new CustomRandom();
		//ran.PRINT();
	}
	
	void Update () 
	{
		processCharacter();
		processKey();
		updateScreen();
	}

	void updateScreen()
	{
	}

	// 몬스터 갱신 .
	void processCharacter()
	{
		for( int i = 0; i <  listCharacter.Count; i++ )
		{
			listCharacter[i].process(myCharacter);
		}
	}

	void processKey()
	{
	}
//	void onMouseMove( POINT pos )
//	{
//	}

}
