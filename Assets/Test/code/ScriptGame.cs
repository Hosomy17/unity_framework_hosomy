using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGame : ScriptGeneric {

	public GameObject player;

	void Start ()
	{
		GetComponent<GamepadGeneric>().controller = new ControllerPlayer (player);
	}

	void Update ()
	{
		
	}
}
