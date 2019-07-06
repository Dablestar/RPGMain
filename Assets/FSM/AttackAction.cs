using UnityEngine;
using System.Collections;
using FSMCustom;

public class AttackAction : CharacterState
{
    Rect rect = new Rect();

    public AttackAction(Character parent)
	{
		parentObj = parent;
		state = eState.STATE_ATTACK;
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
		
		if( rect.Contains( new Vector2(ch.getPosition().x, ch.getPosition().z )) == false )
		{
            Debug.Log("Event.EVENT_LOSTTARGET");
			parentObj.setTransition( eEvent.EVENT_LOSTTARGET );
			return;
		}
		parentObj.MoveTo( ch.getPosition() );
	}
}
