using UnityEngine;
using System.Collections;

public class PlayerController : NewController {


	public bool leftHandIsHooked = false;
	public bool rightHandIsHooked = false;

	public Vector2 lefthandHolePosition;

	GameObject leftHand;

	

	// Use this for initialization
	void Start () {
		Debug.Log ("Player " + prefix);
		leftHand = GameObject.FindGameObjectWithTag (prefix + "_LeftHand");
	}
	
	// Update is called once per frame
	void Update () {

		if (leftHandIsHooked == false) {
			MoveLeftHand ();
		} else {
			leftHand.gameObject.GetComponent<Rigidbody2D> ().transform.position = lefthandHolePosition;
		}


		MoveRightHand ();

	}


	private void MoveLeftHand(){
		

		if (GetLeftStick ().magnitude > 0) {
			
			leftHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetLeftStick () * 10);
		}

	}

	private void MoveRightHand(){
		if (GetRightStick ().magnitude > 0) {
			GameObject rightHand = GameObject.FindGameObjectWithTag (prefix + "_RightHand");
			rightHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetRightStick () * 10);
		}
	}


}
