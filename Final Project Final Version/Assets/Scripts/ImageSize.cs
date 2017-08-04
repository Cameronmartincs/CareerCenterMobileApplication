using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSize : MonoBehaviour {
	public Canvas c;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RectTransform cTransform = c.GetComponent<RectTransform> ();
		this.GetComponent <RectTransform> ().sizeDelta = new Vector3 (cTransform.rect.width, cTransform.rect.height);
		
	}
}
