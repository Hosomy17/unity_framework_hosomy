using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBody : ClassGeneric
{
	public float speed;
	public float forceJump;
	public GameObject super;

	public float delay;
	public int pos;
	public Timer time;
	public bool isCombo;
	public Vector2 lastCombo;
	public ArrayList lstCombo;
	void Start()
	{
		time = new Timer ();
		pos = 0;
		lstCombo = new ArrayList();
		lstCombo.Add (new Vector2 (0,-1));
		lstCombo.Add (new Vector2 (1,-1));
		lstCombo.Add (new Vector2 (1,0));
	}

	public bool IsCombo()
	{
		var r = time.GetTime() <= delay && isCombo;
		pos = 0;
		isCombo = false;

		return r;
	}

	public void NextCombo(Vector2 dir)
	{
		if (dir.x == ((Vector2)lstCombo [pos] ).x && dir.y == ((Vector2)lstCombo [pos] ).y) {
			if (pos == 0)
				time.Reset ();

			if (time.GetTime () <= delay) {
				pos++;
				if (pos == lstCombo.Count) {
					pos = 0;
					isCombo = true;
				}
			} else if (dir.x == ((Vector2)lstCombo [0] ).x && dir.y == ((Vector2)lstCombo [0] ).y)
			{
				time.Reset ();
				pos = 1;
			}
		} else if(lastCombo.x != dir.x || lastCombo.y != dir.y)
		{
			pos = 0;
		}

		lastCombo = dir;
	}

}
