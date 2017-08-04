using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {
	public Canvas c;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RectTransform cTransform = c.GetComponent<RectTransform> ();
		this.GetComponent <RectTransform> ().sizeDelta = new Vector3 (cTransform.rect.width - cTransform.rect.width/6 , cTransform.rect.height/3);
		this.GetComponent <RectTransform> ().anchoredPosition = new Vector2 (0, - this.GetComponent <RectTransform> ().rect.height / 2);
	}
}
