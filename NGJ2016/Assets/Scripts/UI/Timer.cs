﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	int minutes = 0;
	int seconds = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//UpdateTime ();

		//Set the text with min and sec
		this.gameObject.GetComponent<Text> ().text = SetText ();


	}


	public void UpdateTime(int time){
		int timer = Mathf.FloorToInt(time);
		minutes = Mathf.FloorToInt(timer / 60);
		seconds = timer % 60;
	}
		
	private string SetText(){

		string _seconds;
		if (seconds < 10)
			_seconds = 0 + seconds.ToString();
		else
			_seconds = seconds.ToString();

		string text = "TIME: " + minutes.ToString() + ":" + _seconds;
		return text;
	}
}
