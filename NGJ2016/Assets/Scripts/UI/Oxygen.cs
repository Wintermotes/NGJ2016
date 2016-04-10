using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour {

	GameObject lm;

	// Use this for initialization
	void Start () {
		lm = GameObject.Find ("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Text> ().text = SetText ();
	}


	private string SetText(){

		int oxygen = Mathf.FloorToInt(lm.GetComponent<LevelManager> ().GetOxygenPercentage ());
		//Debug.Log ("oxygen = " + oxygen);
		return "OXYGEN " + oxygen.ToString() + "%";
	}
}

