using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBody : ControllerGeneric
{
	private ClassBody body;
	private GameObject objBody;
	private GameObject super;

	public ControllerBody(GameObject obj)
	{
		TrackObject (obj);
	}

	public override void NewInputs (Dictionary<string, object> ipt)
	{
		body.NextCombo ((Vector2)ipt ["Axis"]);

		if (ipt ["Fire1"] as string == "Down")
		{
			if (body.IsCombo())
				Fire ();
			else
				Push ();

		}

		if (ipt ["Fire2"] as string == "Down")
		{
			Jump ();
		}

		if (ipt ["Fire3"] as string == "Down")
		{
			Fire ();
		}

		Move ((Vector2)ipt["Axis"]);
	}

	public override void TrackObject (GameObject obj)
	{
		body = obj.GetComponent<ClassBody>();
		objBody = obj;
		super = body.super;
	}

	public void Push()
	{
		BehaviourAnimation.Play (objBody, "attack");
	}

	public void Fire()
	{
		Push ();
		var obj = super.Spawn (objBody.transform.position);
		BehaviourPhysics.Move2D (obj, Vector2.right, 10);
	}

	public void Move(Vector2 dir)
	{
		dir.y = 0;
		if (true)
		{
			if (dir.x != 0)
				BehaviourPhysics.Move2D (objBody, dir, body.speed);
			else
				BehaviourPhysics.Move2D (objBody, Vector2.right, 0);
		}
	}

	public void Jump()
	{
		BehaviourPhysics.Move2D (objBody, Vector2.up, 0);
		BehaviourPhysics.Force2D (objBody, Vector2.up, body.forceJump);
	}
}
