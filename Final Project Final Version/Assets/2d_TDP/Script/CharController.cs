using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {
	private Animator anim;
	public float speed;
	public int progress;
	public int completed;
	private string[] tasksStatus = new string [7];
	public GameObject gameUnlock;

	//private bool beingHandled = false;
	private string[] dialog = new string[]{ //Greeting 0-4
											"Greeting...", 
											"Lets walk down the Saints Have a Plan path to success!!",
											"If you havent already, make sure to make your profile.",
											"As you complete objectives with the Career center, I will update you on whats next.", 
											"Who knows, there may be some secrets hidden down this road....",
											//Profile Park 5
											"Its time to head to profile Park. Head to the Career center website to make your Saints Have A Plan Profile.",
											//25% 6 - 7
											"Congratulations, You've made your online profile, now you can start on your tasks.",
											"Next we need to go down Resume Road, here your task is to create a Resume.",
											//Resume Road 8 - 9
											"Here you must create a resume, make sure to turn it into the Career Center Website.",
											"If you need help, make sure to go into the Career Center on Campus, they'd love to have you.",
											//50% 10
											"Congrats, you are half way done. Resume looks good, lets work on that cover letter.",
											//CoverLetter Curve 11
											"Here we will work on your cover letter. It's very important for employers to understand your soft skills.",
											//75% 12
											"Look at you, your almost done. Now that you have your materials. Go make a profile on Linkdn.",
											//Linkdn Lane 13 -15
											"Linkdn is very important for employers to reach out to you. Its the facebook of professionalism!",
											"Suprise, go to your profile page and play the game you have unlcoked",
											"If you beat a score of 400 you unlock a free coffee card",
											//100% 16
											"Look at that, you're all done! Congratulations.",
											//Get Raffle Tickets and T-Shirt 17 - 20
											"Now that all objectives are complete. Make sure to head down to the Career Center.",
											"You have a free t-shirt and raffle tickets waiting for you.",
											"Remember to update all your information in your materials.",
											"Good luck on your life of success!",
	};
	public GameObject character;
	private AssemblyCSharp.PixelBubble pBubble;

	void Start () {
		progress = 0;
		anim = GetComponent<Animator> ();
		//change greeting to include username
		dialog [0] = "Hi " + PlayerPrefs.GetString ("First_Name") + ", I'm Marty the SMU Mascot";
		ChangeSpeech (dialog, 0, 0);
		character.GetComponent<DialogBubble> ().ShowBubble (character.GetComponent<DialogBubble> ());

		tasksStatus [0] = PlayerPrefs.GetString ("Plan_Status");
		tasksStatus [1] = PlayerPrefs.GetString ("Resume_Status");
		tasksStatus [2] = PlayerPrefs.GetString ("Cover_Letter_Status");
		tasksStatus [3] = PlayerPrefs.GetString ("LinkedIn_Status");
		tasksStatus [4] = PlayerPrefs.GetString ("EventType");
		tasksStatus [5] = PlayerPrefs.GetString ("Internship_Statu");
		tasksStatus [6] = PlayerPrefs.GetString ("Reward");

	

		if (tasksStatus [3] == "True" && tasksStatus [2] == "True" && tasksStatus [1] == "True" && tasksStatus [0] == "True") {
			//buttons [3].GetComponent<Toggle> ().isOn = true;
			this.GetComponent<CharController> ().completed = 9;
			gameUnlock.SetActive (true);
		} else if (tasksStatus [2] == "True" && tasksStatus [1] == "True" && tasksStatus [0] == "True") {
			//buttons [2].GetComponent<Toggle> ().isOn = true;
			this.GetComponent<CharController> ().completed = 8;
			gameUnlock.SetActive (true);
		} else if (tasksStatus [1] == "True" && tasksStatus [0] == "True") {
			//buttons [1].GetComponent<Toggle> ().isOn = true;
			this.GetComponent<CharController> ().completed = 6;
		} else if (tasksStatus [0] == "True") {
			//buttons [0].GetComponent<Toggle> ().isOn = true;
			this.GetComponent<CharController> ().completed = 4;

		} else 
		{
			this.GetComponent<CharController> ().completed = 2;
		}
		//example
		//MoveAndChange (dialog, new Vector3 (0, 0, 0), 0, 4);


		//use to test all text

	/*	for (int i = 0; i < 2; i++) {
			character.GetComponent<DialogBubble> ().vBubble.Add (new AssemblyCSharp.PixelBubble ());
			pBubble = character.GetComponent<DialogBubble> ().vBubble [i];
			pBubble.vMessage = dialog [i];
			pBubble.vClickToCloseBubble = true;
		}*/
	

	}

	
	// Update is called once per frame
	void Update () {
		DialogBubble cDb = character.GetComponent<DialogBubble> ();
		Vector2 currentPosition = character.GetComponent<RectTransform> ().anchoredPosition;
		bool started = character.GetComponent<DialogBubble> ().started;
		//Debug.Log (cDb.vCurrentBubble);
		//Debug.Log (started);

		//104, 186

		switch (progress) 
		{
		case 1:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					//ChangeSpeech (dialog, 5, 5);
					//progress = 2;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						ChangeSpeech (dialog, 5, 5);
						progress++;
					}

				}
				anim.Play ("Shrink");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(276,76), 0.05f);
				break;
			}

		case 2:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					//ChangeSpeech (dialog, 6, 7);

					//progress = 3;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						ChangeSpeech (dialog, 6, 7);
						progress++;
					}
				}
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(407,215), 0.05f);
			
				break;
			}
		case 3:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					//ChangeSpeech (dialog, 8, 9);

					//progress = 4;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						ChangeSpeech (dialog, 8, 9);
						progress++;
					}
				}
				anim.Play ("Expand");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(400,399), 0.05f);
			
				break;
			}
		case 4:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					
				
					//progress = 5;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						ChangeSpeech (dialog, 10, 10);
						progress++;
					}
				}
				anim.Play ("Shrink");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(208,459), 0.05f);
			
				break;
			}
		case 5:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					
				
					//progress = 6;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						ChangeSpeech (dialog, 11, 11);
						progress++;
					}
				}
				anim.Play ("Expand");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(66,623), 0.05f);
			
				break;
			}
		case 6:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					

					//progress = 7;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						ChangeSpeech (dialog, 12, 12);
						progress++;
					}
				}
				anim.Play ("Shrink");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(227,918), 0.05f);

				break;
			}
		case 7:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					
					//progress = 8;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						ChangeSpeech (dialog, 13, 15);
						progress++;
					}
				}
				anim.Play ("Expand");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(460,868), 0.05f);
		
				break;
			}
		case 8:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					//ChangeSpeech (dialog, 14, 18);
					//progress = 9;
					//ChangeSpeech (dialog, 17, 20);
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						progress++;
						ChangeSpeech (dialog, 17, 20);
					}
				}
				anim.Play ("Shrink");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(400,970), 0.05f);
		
				break;
			}
		case 9:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					
					//progress = 10;
					character.GetComponent<DialogBubble> ().started = false;
					if (progress < completed) 
					{
						progress++;
					}
				}
				anim.Play ("Expand");
				character.GetComponent<RectTransform> ().anchoredPosition = Vector2.Lerp (currentPosition, new Vector2(333,921), 0.05f);
			
				break;
			}
		default:
			{
				if(cDb.vCurrentBubble == null && started == true)
				{
					ChangeSpeech (dialog, 1, 4);
					
					progress = 1;
					character.GetComponent<DialogBubble> ().started = false;
				}
				character.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (104, 186);
			
				break;
			}

		}








	}
/*	private IEnumerator HandleIt()
	{
		beingHandled = true;
		yield return new WaitForSeconds (3.0f);
		beingHandled = false;
	}*/

	//Use array of speech, location to move, start of array to show, end of array to show
	public void ChangeSpeech(string[] speech, int start, int end)
	{
		character.GetComponent<DialogBubble> ().vBubble.RemoveRange(0, character.GetComponent<DialogBubble> ().vBubble.Count);
		int loopEnd = end - start;
		for (int i = 0; i <= loopEnd; i++) {
			character.GetComponent<DialogBubble> ().vBubble.Add (new AssemblyCSharp.PixelBubble ());
			pBubble = character.GetComponent<DialogBubble> ().vBubble [i];
			pBubble.vMessage = speech [start];
			pBubble.vClickToCloseBubble = true;
			start++;
		}

	}

		
}


//map width = 800 , 1131.8
/*
NPC size = 100, 100 with 100,100 scale

first location = 105.01, 119.3, 0

2 location = 596.8, 167.2, 0

3 location = 543.7, 325.9, 0

4 location = 264.7, 437.6, 0

5 location = 84.2, 572.9, 0

6 location = 225.5, 824, 0

7 location = 474.7, 760.8, 0

8 location = 550.1, 871.2, 0

9 location = 363.3, 1030.4, 0*/

