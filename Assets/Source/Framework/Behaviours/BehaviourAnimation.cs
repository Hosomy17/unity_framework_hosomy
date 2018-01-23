using UnityEngine;
using System.Collections;

///<summary>
///Animations methods for Animator and  SpriteRenderer
///</summary>
public static class BehaviourAnimation
{
    public static void Play(GameObject obj, string ani)
    {
        obj.GetComponent<Animator>().Play(ani);
    }

    public static void Trigger(GameObject obj, string trg)
    {
        obj.GetComponent<Animator>().SetTrigger(trg);
    }

    public static void ResetTrigger(GameObject obj, string trg)
    {
        obj.GetComponent<Animator>().ResetTrigger(trg);
    }

    public static void Flip(GameObject obj, Vector2 dir)
    {
        SpriteRenderer spr = obj.GetComponent<SpriteRenderer>();
        
        if (dir.x == 1)
            spr.flipX = false;
        else if (dir.x == -1)
            spr.flipX = true;

        if (dir.y == 1)
            spr.flipY = false;
        else if (dir.y == -1)
            spr.flipY = true;
    }

	public static void ChangeLayer(GameObject obj, int lay)
	{
		SpriteRenderer spr = obj.GetComponent<SpriteRenderer>();
		spr.sortingOrder = lay;
	}

	public static void ChangeAngle(GameObject obj, Vector2 dir)
	{
		if (dir.x == 1) {
			if (dir.y == 1)
				obj.transform.eulerAngles = Vector3.forward * 45;
			else if (dir.y == -1)
				obj.transform.eulerAngles = Vector3.forward * 315;
			else
				obj.transform.eulerAngles = Vector3.forward * 0;
		} else if (dir.x == -1) {
			if (dir.y == 1)
				obj.transform.eulerAngles = Vector3.forward * 135;
			else if (dir.y == -1)
				obj.transform.eulerAngles = Vector3.forward * 225;
			else
				obj.transform.eulerAngles = Vector3.forward * 180;
		} else if (dir.y == 1) {
			obj.transform.eulerAngles = Vector3.forward * 90;
		} else if (dir.y == -1) {
			obj.transform.eulerAngles = Vector3.forward * 270;
		}
	}
}
