using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Check gamepad with n buttons and directional
/// buttons can be {Down,Up,Hold,Idle}
/// directional can be x = [-1,0,1], y [-1,0,1]
/// </summary>
public class Gamepad : GamepadGeneric
{
    public Dictionary<string,object> inputs;
	public int buttons;
	public string name;

    void Awake()
    {
		inputs = new Dictionary<string, object>();

		for(int i=0; i < buttons; i++)
			inputs.Add("Fire"+i, "Idle");
		inputs.Add("Axis" , Vector2.zero);
	}

	void Update ()
    {
		try
		{
			for (int i = 1; i <= buttons; i++)
			{

				inputs["Fire" + i]  = Input.GetButtonDown ("Fire" + i + name)  ? "Down" :
									  Input.GetButton ("Fire" + i + name) 	   ? "Hold" :
									  Input.GetButtonUp ("Fire" + i + name)    ? "Up"   : "Idle";
	        }

			inputs["Axis"] = GetAxis();
			controller.NewInputs(inputs);
		}
		catch//(Exception e)
		{
			//Debug.LogError(e);
		}
	}

    private Vector2 GetAxis()
    {
        Vector2 axis = new Vector2();

        axis.x = Input.GetAxisRaw("Horizontal" + name);
        axis.y = Input.GetAxisRaw("Vertical" + name);

        return axis;
    }
}
