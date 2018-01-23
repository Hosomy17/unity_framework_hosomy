using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ControllerGeneric
{
	public abstract void NewInputs(Dictionary<string, object> ipt);

    public abstract void TrackObject(GameObject obj);
}