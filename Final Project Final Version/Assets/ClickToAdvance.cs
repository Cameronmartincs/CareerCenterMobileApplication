using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAdvance : MonoBehaviour {
	public GameObject messageBubble;
	public GameObject pointer;
	public string[] messages;

	int count;
	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		//messageBubble.GetComponent<TextMesh> ().text = "hi";
		count = 1;
		for (int i = 0; i < messages.Length; i++) 
		{
			messages[i] = messages [i].Replace ("NEWLINE", "\n");
		}
		messageBubble.GetComponent<TextMesh> ().text = messages [0];
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit) && Input.GetMouseButtonDown (0)) {
			//only return NPC
			if (hit.transform == this.transform) {
				
				//check the bubble on the character and make it appear!
				if (messages.Length >= 0) {
					
					messageBubble.GetComponent<TextMesh> ().text = messages [count];
					pointer.GetComponent<MovePointer> ().move = count;

					count += 1;
				} 
				if (count == messages.Length) 
				{
					count = 0;
				}
			

			}
		}

		
	}
}
