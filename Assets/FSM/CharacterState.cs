using UnityEngine;
using System.Collections;
using FSMCustom;

public abstract class CharacterState {

	protected	Character	parentObj;
	public eState state;

	public CharacterState() {}

	public	CharacterState( Character parent )
	{
		parentObj = parent;
	}
	public abstract void move();
	public abstract void attack();
	public abstract void process( Character ch );
}
