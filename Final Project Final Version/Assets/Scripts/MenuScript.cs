using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour {
	public Button myButton;
	public Button myButton2;
	//refrence for the pause menu panel in the hierarchy
	public GameObject sidePanel;
	//animator reference
	private Animator anim;
	// Use this for initialization
	void Start () {
	  //get the animator component
		anim = sidePanel.GetComponent<Animator>();

	  //disable it on start to stop it from playing the default animation
	  anim.enabled = false;
	}

	// Update is called once per frame
	public void Update () {		
	}

	public void SlideIn(){
		//enable the animator component
		anim.enabled = true;
		//play the Slidein animation
		anim.Play("SlideInMenu");
	}
	public void SlideOut(){
		//enable the animator component
		anim.enabled = true;
		//play the SlideOut animation
		anim.Play("SlideOutMenu");
	}
}
