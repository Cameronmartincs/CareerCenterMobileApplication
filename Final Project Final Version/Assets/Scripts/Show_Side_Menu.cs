using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Side_Menu : MonoBehaviour {

	public GameObject panelObject;
	public Button myButton;


	// Use this for initialization
	void Start () {
		myButton.GetComponent<Button>().onClick.AddListener (() => {
			panelObject.SetActive (true);
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
