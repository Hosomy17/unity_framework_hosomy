using UnityEngine;
using System.Collections;

public static class BehaviourSound
{

	public static void Play(AudioClip audio)
	{
        AudioSource.PlayClipAtPoint(audio, Vector3.zero);
	}

}
