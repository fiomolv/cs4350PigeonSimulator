using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAnimation : MonoBehaviour {

	public Animation anim;
	public string name;

	void Start()
	{
		// Set the wrap mode of the walk animation to loop
		anim[name].wrapMode = WrapMode.Loop;
	}
}
