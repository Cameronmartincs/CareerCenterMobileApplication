using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimTest : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Animation anim = GetComponent<Animation> ();

		AnimationClip ac = anim.GetClip ("MovePark");

		Debug.Log (ac.name + " " + anim.GetClipCount () + " ");
		AnimationCurve curve = AnimationCurve.Linear (0.0f, 1.0f, 2.0f, 0.0f);

		//clip.legacy = true;
		ac.SetCurve("", typeof(Transform), "Anchored Position.x", curve);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
