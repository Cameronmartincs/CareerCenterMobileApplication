using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FooterSize : MonoBehaviour {
	public Canvas c;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RectTransform cTransform = c.GetComponent<RectTransform> ();
		this.GetComponent <RectTransform> ().sizeDelta = new Vector3 (cTransform.rect.width, cTransform.rect.height/7);
		this.GetComponent <RectTransform> ().anchoredPosition = new Vector2 (0, this.GetComponent <RectTransform> ().rect.height / 2);
		
	}
}
