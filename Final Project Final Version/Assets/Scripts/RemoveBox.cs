using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveBox : MonoBehaviour {
	public GameObject[] buttons;

	private string[] tasksStatus = new string [7];
	void Start()
	{
		tasksStatus [0] = PlayerPrefs.GetString ("Plan_Status");
		tasksStatus [1] = PlayerPrefs.GetString ("Resume_Status");
		tasksStatus [2] = PlayerPrefs.GetString ("Cover_Letter_Status");
		tasksStatus [3] = PlayerPrefs.GetString ("LinkedIn_Status");
		tasksStatus [4] = PlayerPrefs.GetString ("EventType");
		tasksStatus [5] = PlayerPrefs.GetString ("Internship_Statu");
		tasksStatus [6] = PlayerPrefs.GetString ("Reward");
		
		CheckBoxes (tasksStatus, buttons);

	}

	public void RemoveImage(GameObject g)
	{
		g.GetComponent<Image> ().enabled = false;
	}

	private void CheckBoxes(string[] tasks, GameObject[] buttons)
	{
		int count = 0;
		foreach (string i in tasks) 
		{
			
			if (tasks [count] == "True") 
			{
				buttons [count].GetComponent<Toggle> ().isOn = true;
			}
			count += 1;
		}
	}
}
