using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		//Set the text with min and sec

	}


	public void SetScore(float score){

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