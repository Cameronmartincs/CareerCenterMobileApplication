using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public GameObject topPanel;
	public GameObject obj;
	public GameObject bottomPanel;
	public GameObject getoutPanel;
	public Canvas canvas;
	public Canvas mapCanvas;
	public Canvas profileCanvas;
	public Canvas contactCanvas;
	public Canvas tasksCanvas;
	public Canvas helpCanvas;

	public Text[] dataProfile = new Text[8];


	Canvas[] canvasArray = new Canvas[5];

	public void DiasableBoolAnimator(Animator anim) {
		anim.SetBool ("IsDisplayed", false);
		getoutPanel.gameObject.SetActive (false);
	}

	public void EnableBoolAnimator(Animator anim) {
		anim.SetBool ("IsDisplayed", true);
		getoutPanel.gameObject.SetActive (true);

	}

	public void StopPanel() {
		Time.timeScale = 0;
	}

	public void UnStopPanel() {
		Time.timeScale = 1;
	}
	public void Start()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		dataProfile [0].text = PlayerPrefs.GetString ("First_Name");
		dataProfile [1].text = PlayerPrefs.GetString ("Last_Name");
		dataProfile [2].text = PlayerPrefs.GetString ("Class_Level");
		dataProfile [3].text = PlayerPrefs.GetString ("SMUemail");
		dataProfile [4].text = PlayerPrefs.GetString ("Advisor");
		dataProfile [5].text = PlayerPrefs.GetString ("Major");
		dataProfile [6].text = "Welcome! "  + PlayerPrefs.GetString ("First_Name");
		dataProfile [7].text = PlayerPrefs.GetString ("ScoreSaved");



		/*	Debug.Log(PlayerPrefs.GetString("Class_Level"));
			Debug.Log(PlayerPrefs.GetString("Major"));
			Debug.Log(PlayerPrefs.GetString("Last_Name"));
			Debug.Log(PlayerPrefs.GetString("Advisor"));*/
	}

	public void Update()
	{

		float bottomPanelHeight = bottomPanel.GetComponent<RectTransform> ().rect.height;
		float topPanelHeight = topPanel.GetComponent<RectTransform> ().rect.height;
		float width = canvas.GetComponent<RectTransform> ().rect.width;
		float height = canvas.GetComponent < RectTransform> ().rect.height;


		//Rect insideRect = new Rect (0, 0, Screen.width, topPanel.GetComponent<RectTransform> ().rect.height);
		//-canvas.GetComponent<RectTransform> ().rect.height +41
		//bottomPanel.GetComponent<RectTransform> ().anchoredPosition = new Vector2(400,bottomPanel.GetComponent<RectTransform> ().rect.height/2 );

		//mapCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, topPanel.GetComponent<RectTransform> ().rect.height - bottomPanelHeight - topPanelHeight);

	//	topPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, Screen.height / 10);
		//bottomPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, Screen.height / 10);

		//changes size of canvases according to screen and panel height at op and bottom
		mapCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height - bottomPanelHeight - topPanelHeight);
		profileCanvas.GetComponent<RectTransform> ().sizeDelta = new Vector2 (width, height - bottomPanelHeight - topPanelHeight);
		contactCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height - bottomPanelHeight - topPanelHeight);
		tasksCanvas.GetComponent<RectTransform> ().sizeDelta = new Vector2(width, height - bottomPanelHeight - topPanelHeight);
		helpCanvas.GetComponent<RectTransform> ().sizeDelta = new Vector2(width, height - bottomPanelHeight - topPanelHeight);
		//Debug.Log (Screen.width + " " + Screen.height);

	}
	public void ChangeCanvas(int select)
	{
		canvasArray [0] = mapCanvas;
		canvasArray [1] = profileCanvas;
		canvasArray [2] = contactCanvas;
		canvasArray [3] = tasksCanvas;
		canvasArray [4] = helpCanvas;

		//set all canvases to inactive
		for (int i = 0; i < canvasArray.Length; i++) 
		{
			canvasArray [i].gameObject.SetActive (false);
		}
		//set specific canvas to active
		canvasArray [select].gameObject.SetActive (true);
	}
	public void SignOut()
	{
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("LoginScreen");
		Debug.Log(PlayerPrefs.GetString("Class_Level"));
		Debug.Log(PlayerPrefs.GetString("Major"));
		Debug.Log(PlayerPrefs.GetString("Last_Name"));
		Debug.Log(PlayerPrefs.GetString("Advisor"));
	}
	public void PlayGame()
	{
		SceneManager.LoadScene ("bowandarrow");
	}
}
