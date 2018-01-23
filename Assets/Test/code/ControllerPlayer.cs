using UnityEngine;
using System.Collections.Generic;

public class ControllerPlayer : ControllerGeneric
{

	private ClassPlayer player;
	private GameObject objPlayer;

	private GameObject gun;
	private GameObject bullet;

	public ControllerPlayer(GameObject obj)
	{
		TrackObject(obj);
	}

	public override void NewInputs (Dictionary<string, object> ipt)
	{
		if (ipt ["Fire1"] as string == "Down")
		{
			Jump ();
		}
		if (ipt ["Fire2"] as string == "Down")
		{
			Shoot();
		}

		Move((Vector2)ipt["Axis"]);
		RotationGun((Vector2)ipt["Axis"]);
	}

	public override void TrackObject (GameObject obj)
	{
		this.player = obj.GetComponent<ClassPlayer>();
		this.objPlayer = obj;
		this.gun = this.player.gun;
		this.bullet = this.player.bullet;
	}

	public void Shoot()
	{
		var obj = bullet.Spawn(gun.transform.position, Quaternion.Euler(gun.transform.eulerAngles));
		var dir = obj.transform.right;
		if (gun.GetComponent<SpriteRenderer> ().flipX)
			dir = -dir;
		BehaviourPhysics.Force2D(obj, dir, player.forceShoot);
	}

	public void Jump()
	{
		BehaviourPhysics.Move2D (this.objPlayer, Vector2.up, 0);
		BehaviourPhysics.Force2D(this.objPlayer, Vector2.up, this.player.forceJump);
	}

	public void Move(Vector2 dir)
	{
		if (dir.x == -1) {
			BehaviourAnimation.Flip (objPlayer, -Vector2.right);
			BehaviourPhysics.Move2D (objPlayer, Vector2.left, player.speed);
		} else if (dir.x == 1) {
			BehaviourAnimation.Flip (objPlayer, Vector2.right);
			BehaviourPhysics.Move2D (objPlayer, Vector2.right, player.speed);
		}
		else
			BehaviourPhysics.Move2D (objPlayer, Vector2.right, 0);
	}

	public void RotationGun(Vector2 dir)
	{
		if (dir.x == -1) {
			if (dir.y == 1)
				BehaviourAnimation.ChangeAngle (gun, new Vector2 (1, -1));
			else if (dir.y == -1)
				BehaviourAnimation.ChangeAngle (gun, Vector2.one);
			else
				BehaviourAnimation.ChangeAngle (gun, Vector2.right);

			BehaviourAnimation.ChangeLayer (gun, 1);
			BehaviourAnimation.Flip (gun, Vector2.left);
		} else if (dir.x == 1) {
			if (dir.y == 1)
				BehaviourAnimation.ChangeAngle (gun, Vector2.one);
			else if (dir.y == -1)
				BehaviourAnimation.ChangeAngle (gun, new Vector2 (1, -1));
			else
				BehaviourAnimation.ChangeAngle (gun, Vector2.right);
			
			BehaviourAnimation.ChangeLayer (gun, 3);
			BehaviourAnimation.Flip (gun, Vector2.right);
		} else if (dir.y == 1) {
			if (gun.GetComponent<SpriteRenderer> ().flipX)
				BehaviourAnimation.ChangeAngle (gun, Vector2.down);
			else
				BehaviourAnimation.ChangeAngle (gun, Vector2.up);

		} else if (dir.y == -1) {
			if (gun.GetComponent<SpriteRenderer> ().flipX)
				BehaviourAnimation.ChangeAngle (gun, Vector2.up);
			else
				BehaviourAnimation.ChangeAngle (gun, Vector2.down);
		}

	}
}
