using UnityEngine;
using System.Collections.Generic;
using System;

public class TouchScreen : GamepadGeneric
{
	public Dictionary<string,object> inputs;
	private string state;
	private Touch lastTouch;

	void Awake()
	{
		inputs = new Dictionary<string, object>();
		inputs.Add("Cursor", Vector2.zero);
		inputs.Add("State", "Idle");
        inputs.Add("Acceleration", Vector2.zero);
        state = "Idle";
	}

	void Update ()
	{
		if (Input.touchCount != 0)
		{
			lastTouch = Input.GetTouch (0);

			switch(state)
			{
			case "Idle":
				state = "Down";
				break;
			case "Down":
				state = "Hold";
				break;
			//case "Hold":
			//	break;
			//case "Up":
			//	break;
			}
		}
		else
		{
			switch(state)
			{
			//case "Idle":
			//	break;
			case "Down":
				state = "Up";
				break;
			case "Hold":
				state = "Up";
				break;
			case "Up":
				state = "Idle";
				break;
			}
		}
		inputs ["Cursor"] = lastTouch.position;
		inputs ["State"] = state;
        inputs ["Acceleration"] = GetAcceleration();

        controller.NewInputs(inputs);
	}

    private Vector3 GetAcceleration()
    {
        return Input.acceleration;
    }

}
