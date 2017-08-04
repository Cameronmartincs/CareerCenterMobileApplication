using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resize : MonoBehaviour {

	public GameObject inputUsername;
	public GameObject inputPassword;
	public GameObject loginButton;
	public Canvas c;
	public GameObject header;
	public GameObject footer;
	public GameObject bckImage;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		RectTransform cTransform = c.GetComponent<RectTransform> ();
		//inputUsername.GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 2f, Screen.height / 13);
		//inputPassword.GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 2f, Screen.height / 13);
		//inputPassword.GetComponent<RectTransform> ().localPosition = new Vector2 (0, -Screen.height / 12);
		//loginButton.GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 4f, Screen.height / 18);
		//loginButton.GetComponent<RectTransform> ().localPosition = new Vector2 (0, -Screen.height / 10);

		bckImage.GetComponent <RectTransform> ().sizeDelta = new Vector3 (cTransform.rect.width, cTransform.rect.height);
		header.GetComponent <RectTransform> ().sizeDelta = new Vector3 (cTransform.rect.width - cTransform.rect.width/6 , cTransform.rect.height/3);
		header.GetComponent <RectTransform> ().anchoredPosition = new Vector2 (0, - header.GetComponent <RectTransform> ().rect.height / 2);

		footer.GetComponent <RectTransform> ().sizeDelta = new Vector3 (cTransform.rect.width, cTransform.rect.height/7);
		footer.GetComponent <RectTransform> ().anchoredPosition = new Vector2 (0, footer.GetComponent <RectTransform> ().rect.height / 2);
	}
}
