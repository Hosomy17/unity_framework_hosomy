using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFollow : MonoBehaviour
{
	public Transform target;
	public float speed;
	public bool ajust;
	public float ppu;
	public Vector3 pos;
	//+----------End
	//-------------
	//-------------
	//-------------
	//Begin-------+
	public Transform limitBoxBegin;
	public Transform limitBoxEnd;

	void Awake()
	{
		pos = Vector3.zero;
	}

	void FixedUpdate ()
	{
		if (ajust)
			AjustLimit ();
		else
			pos = target.localPosition;
		
		pos = Vector3.Lerp (transform.localPosition,pos,Time.deltaTime * speed);
		pos.z = transform.localPosition.z;
		transform.localPosition = pos;
	}

	private void AjustLimit()
	{
		//pixel per unit = 100 = width/2 / ppu;
		var size = GetComponent<Camera> ().pixelWidth/ppu;
		pos.x = (target.localPosition.x <= limitBoxBegin.localPosition.x + size) ? limitBoxBegin.localPosition.x + size :
				(target.localPosition.x >= limitBoxEnd.localPosition.x   - size) ? limitBoxEnd.localPosition.x   - size :
				target.localPosition.x;

		//pixel per unit = 100 = height/2 / ppu;
		size = GetComponent<Camera> ().pixelHeight/ppu;
		pos.y = (target.localPosition.y <= limitBoxBegin.localPosition.y + size) ? limitBoxBegin.localPosition.y + size :
				(target.localPosition.y >= limitBoxEnd.localPosition.y  - size)  ? limitBoxEnd.localPosition.y   - size :
				target.localPosition.y;
	}
}
