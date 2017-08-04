using System.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoginTest : MonoBehaviour {
	public Text inputUsername;
	public Text inputPassword;
	public Text confirmText;
	string placeholder = null;



	public void Loginclick(){
		string username = inputUsername.text;
		try{


			//TODO: change connection String
			//Data Source = 192.168.1.178,1433; 192.168.1.178,1433
			string constr = "Data Source = 127.0.0.1,1433; Initial Catalog = 480Project; Uid=garcia; Pwd=g;";
	
			SqlConnection con = new SqlConnection(constr);
			con.Open();
			confirmText.text = "Open";
			//SqlCommand com = new SqlCommand(@"SELECT aname from agents where aid = @username", con);
			SqlCommand com = new SqlCommand(@"Select s.PCID, First_name, Last_Name, Class_Level,Major, SMUemail, Advisor, 
											s.Plan_Status,s.Resume_Status,s.Cover_Letter_Status,s.LinkedIn_Status,c.EventType,s.Internship_Status,s.Reward
											FROM Seniors AS s
											Join People AS p ON s.PCID = p.Student_ID
											Left Join CareerEvents AS C ON s.EventID = c.EventID where SMUemail = @username", con);
			

										


			com.Parameters.Add("@username", SqlDbType.NVarChar, 100);
			com.Parameters["@username"].Value = inputUsername.text + "@stmartin.edu";
		
	
			confirmText.text = "connected";
	
	
			SqlDataReader reader = com.ExecuteReader();
			while (reader.Read ()) 
			{
				
				placeholder = reader.GetString (1);
				//Debug.Log (username + " " + placeholder);
				if(placeholder == inputPassword.text)
				{
					

					SqlConnection conn = new SqlConnection(constr);
					conn.Open();
					SqlCommand comm = new SqlCommand(@"Select BowAndArrow from SeniorGameScore where PCID = @PCID",conn );
					comm.Parameters.Add("@PCID", SqlDbType.NVarChar, 100);
					comm.Parameters["@PCID"].Value = reader.GetString(0);

					SqlDataReader readerc = comm.ExecuteReader();
					while (readerc.Read ()) 
					{
						PlayerPrefs.SetString("ScoreSaved", Convert.ToString(readerc.GetValue(0)));
						PlayerPrefs.Save();
					
					}
					readerc.Close();
					conn.Close();

					PlayerPrefs.SetString("PCID", reader.GetString(0));
					PlayerPrefs.SetString("First_Name", reader.GetString(1));
					PlayerPrefs.SetString("Last_Name", reader.GetString(2));
					PlayerPrefs.SetString("Class_Level", reader.GetString(3));
					PlayerPrefs.SetString("Major", reader.GetString(4));
					PlayerPrefs.SetString("SMUemail",  reader.GetString(5));
					PlayerPrefs.SetString("Advisor", reader.GetString(6));
					PlayerPrefs.SetString("Plan_Status", Convert.ToString(reader.GetValue(7)));
					PlayerPrefs.SetString("Resume_Status", Convert.ToString(reader.GetValue(8)));
					PlayerPrefs.SetString("Cover_Letter_Status", Convert.ToString(reader.GetValue(9)));
					PlayerPrefs.SetString("LinkedIn_Status", Convert.ToString(reader.GetValue(10)));
					PlayerPrefs.SetString("EventType", Convert.ToString(reader.GetValue(11)));
					PlayerPrefs.SetString("Internship_Status", Convert.ToString(reader.GetValue(12)));
					PlayerPrefs.SetString("Reward", Convert.ToString(reader.GetValue(13)));
					//PlayerPrefs.SetString("Internship_Status", Convert.ToString(reader.GetBoolean(11)));	
					PlayerPrefs.Save();

					/*Debug.Log(PlayerPrefs.GetString("PCID"));
					Debug.Log(PlayerPrefs.GetString("First_Name"));
					Debug.Log(PlayerPrefs.GetString("Last_Name"));
					Debug.Log(PlayerPrefs.GetString("Advisor"));
					Debug.Log(PlayerPrefs.GetString("Class_Level"));
					Debug.Log(PlayerPrefs.GetString("Major"));
					Debug.Log(PlayerPrefs.GetString("SMUemail"));
					Debug.Log(PlayerPrefs.GetString("Plan_Status"));
					Debug.Log(PlayerPrefs.GetString("Resume_Status"));
					Debug.Log(PlayerPrefs.GetString("Cover_Letter_Status"));
					Debug.Log(PlayerPrefs.GetString("LinkedIn_Status"));
					Debug.Log(PlayerPrefs.GetString("EventType"));
					Debug.Log(PlayerPrefs.GetString("Internship_Statu"));
					Debug.Log(PlayerPrefs.GetString("Reward"));

					Debug.Log (username + " " + placeholder);*/
					SceneManager.LoadScene("CanvasMenu");
					reader.Close();
					con.Close ();
					break;

				}
			
			}
			if(!reader.IsClosed)
			{
			reader.Close();
			con.Close ();
			confirmText.text = "closed";
			}

		
		}
		//Bad practice, would need to create user class and use validate result instead of catching exceptions
		finally
		{
			if(username == null || username == "")
			{
				throw new Exception ("No username");
			}
		
			if (inputPassword.text == null || inputPassword.text == "") 
			{
				throw new Exception ("No Password");
			}
			else if(placeholder != inputPassword.text) 
			{
				throw new Exception ("Wrong Password or Username");

			}
		}

		/*catch (Exception ex)
		{
			
			Debug.Log("Wrong Password!!");
	

		}*/

	
	}
		

	public void Override()
	{
		PlayerPrefs.SetString("First_Name", "John");
		PlayerPrefs.SetString("Last_Name", "Smith");
		PlayerPrefs.SetString("Class_Level", "Senior");
		PlayerPrefs.SetString("Major", "Computer Science");
		PlayerPrefs.SetString("SMUemail", "jsmith@stmartin.edu");
		PlayerPrefs.SetString("Advisor", "Motz");
		PlayerPrefs.SetString("Plan_Status", "True");
		PlayerPrefs.SetString("Resume_Status", "True");
		PlayerPrefs.SetString("Cover_Letter_Status", "True");
		PlayerPrefs.SetString("ScoreSaved", "0");

		SceneManager.LoadScene("CanvasMenu");
	}


	public void Override2()
	{
		PlayerPrefs.SetString("First_Name", "Joe");
		PlayerPrefs.SetString("Last_Name", "Doe");
		PlayerPrefs.SetString("Class_Level", "Senior");
		PlayerPrefs.SetString("Major", "Computer Science");
		PlayerPrefs.SetString("SMUemail", "jsmith@stmartin.edu");
		PlayerPrefs.SetString("Advisor", "Motz");
		PlayerPrefs.SetString("Plan_Status", "True");
		PlayerPrefs.SetString("Resume_Status", "True");
		PlayerPrefs.SetString("Cover_Letter_Status", "False");
		PlayerPrefs.SetString("LinkedIn_Status", "True");
		PlayerPrefs.SetString("ScoreSaved", "0");

		SceneManager.LoadScene("CanvasMenu");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
