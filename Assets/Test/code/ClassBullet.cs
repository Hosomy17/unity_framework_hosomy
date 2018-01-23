using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBullet : ClassGeneric
{
	
	void Update()
	{
		var dir = GetComponent<Rigidbody2D>().velocity;
		if (dir.x != 0 && dir.y != 0) {
			var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name != "Player") {
			GetComponent<Rigidbody2D> ().gravityScale = 0;
			BehaviourPhysics.Move2D (gameObject, Vector2.one, 0);
		}
	}
}
