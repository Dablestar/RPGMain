using UnityEngine;
using System.Collections;
using FSMCustom;

public class MoveAction : CharacterState
{
    Rect rect = new Rect();
    Vector3 destPos = new Vector3();

	public MoveAction( Character parent )
	{
		parentObj = parent;
		state = eState.STATE_MOVE;
		destPos.x = Random.Range(0,20);
        destPos.y = 0;
		destPos.z = Random.Range(0,20);
	}

	public override void move()
	{

	}

	public override void attack()
	{
	}


	public override void process( Character ch )
	{
		rect.Set( parentObj.getPosition().x - parentObj.getRadius(),
		          parentObj.getPosition().z - parentObj.getRadius(),
		          parentObj.getPosition().x + parentObj.getRadius(),
		          parentObj.getPosition().z + parentObj.getRadius());

		if( rect.Contains( new Vector2( ch.getPosition().x, ch.getPosition().z )))
		{
			Debug.Log ( "EVENT_FINDTARGET" );
			parentObj.setTransition( eEvent.EVENT_FINDTARGET );
			return;
		}
		
		rect.Set( parentObj.getPosition().x - 5,
		          parentObj.getPosition().z - 5,
		          parentObj.getPosition().x + 5,
		          parentObj.getPosition().z + 5 );
		
		if( rect.Contains( new Vector2( destPos.x, destPos.z )))
		{
			destPos.x = Random.Range(0,20);
            destPos.y = 0;
            destPos.z = Random.Range(0,20);

//			Debug.Log ( "EVENT_STOPWALK" + destPos.x + "  " + destPos.y);
			parentObj.setTransition( eEvent.EVENT_STOPWALK );
			return;
		}

		parentObj.MoveTo( destPos);
	}
}
