using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointer : MonoBehaviour {
	public int move;
	Animator anim;
	public GameObject bMess;
	// Use this for initialization
	void Start () {
		bMess.GetComponent<MeshRenderer> ().sortingOrder = 5;
	}
	
	// Update is called once per frame
	void Update () {
		anim = GetComponent<Animator> ();
		anim.SetInteger ("HelpNum", move);
	}
}
