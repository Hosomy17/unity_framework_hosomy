using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLuta : ScriptGeneric {

	public GameObject player;

	void Start ()
	{
		GetComponent<GamepadGeneric>().controller = new ControllerBody (player);
	}

	void Update ()
	{

	}
}
