using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	GameObject lm;

	// Use this for initialization
	void Start () {
		lm = GameObject.Find ("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void SetScore(float score){

		//Negate the prev passed time
		int prevPassedTime = lm.GetComponent<LevelManager> ().GetPassedSessionTime ();
		score -= prevPassedTime;

		//Create timer string
		int timer = Mathf.FloorToInt(score);
		int minutes = Mathf.FloorToInt(timer / 60);
		int seconds = timer % 60;
		string _seconds;
		if (seconds < 10)
			_seconds = 0 + seconds.ToString();
		else
			_seconds = seconds.ToString();

		string scoreTime = minutes + ":" + _seconds;

		string text = "you lasted " + scoreTime;
		this.gameObject.GetComponent<Text> ().text = text;
	}
}