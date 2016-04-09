using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	private bool plugged = false;

	private enum state {active, inactive, dead, invulnerable};
	private state playerState;

	private enum Button {SQUARE, X, ROUND, TRIANGLE, PAD_LEFT, PAD_RIGHT, PAD_UP, PAD_DOWN };
	private Button button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		SetButton ();
		SetPosition ();
	}

	private void SetPosition(){
		this.transform.position = new Vector2 (Random.Range (0f, 10f), Random.Range (0f, 10f));
		Debug.Log ("pos = " + GetPosition ());
	}

	/**
	 * Assigns a random button
	 */
	private void SetButton(){
		button = (Button)Random.Range(0, 7);
	}

	public Vector2 GetPosition(){
		return this.transform.position;
	}

	public bool IsPlugged(){
		return this.plugged;
	}


}
