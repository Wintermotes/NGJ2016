using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//The 'energy' bar
	private int oxygenCounter = 1000;

	//Seconds passed in the level
	private int timer = 0;

	private HoleManager hm;


	// Use this for initialization
	void Start () {
		hm = this.gameObject.GetComponent<HoleManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		hm.CreateNewHole ();

		UpdateTimer ();
		Debug.Log ("Timer = " + timer);
		if(timer % 10 == 0)
			hm.CreateNewHole ();
	
	}

	private void UpdateTimer(){
		timer 	= Mathf.FloorToInt(Time.deltaTime);
	}
}
