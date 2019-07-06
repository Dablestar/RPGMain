using UnityEngine;
using System.Collections;
using FSMCustom;

public class StandAction : CharacterState 
{
    Rect rect = new Rect();

    public StandAction( Character parent )
	{
		parentObj = parent;
		state = eState.STATE_STAND;
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
		
		if( rect.Contains( new Vector2(ch.getPosition().x,ch.getPosition().z )) == true )
		{
			parentObj.setTransition( eEvent.EVENT_FINDTARGET );
			
			return;
		}
		
		if( Random.Range(0,100) < 5 )
		{
			parentObj.setTransition( eEvent.EVENT_PATROL );
			return;
		}
	}
}
