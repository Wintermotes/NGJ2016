using UnityEngine;
using System.Collections;

public class PlayerController : NewController {


	public bool leftHandIsHooked = false;
	public bool rightHandIsHooked = false;

	public Vector2 lefthandHolePosition;
	public Vector2 righthandHolePosition;


	GameObject leftHand;
	GameObject rightHand;
	

	// Use this for initialization
	void Start () {
		
		leftHand = GameObject.FindGameObjectWithTag (prefix + "_LeftHand");
		rightHand = GameObject.FindGameObjectWithTag (prefix + "_RightHand");
		Debug.Log ("Player " + prefix);
		Debug.Log ("leftHand " + leftHand);
		Debug.Log ("rightHand " + rightHand);
	}
	
	// Update is called once per frame
	void Update () {
		
		MoveLeftHand ();

		MoveRightHand ();

//		if (rightHandIsHooked == false) {
//			MoveRightHand ();
//		} else {
//			rightHand.gameObject.GetComponent<Rigidbody2D> ().transform.position = righthandHolePosition;
//		}
	}


	private void MoveLeftHand(){
		Debug.Log ("leftHand " + leftHand);
		if (leftHand.gameObject.GetComponent<Hand> ().IsHooked () == false) {
			
			if (GetLeftStick ().magnitude > 0) {
			
				leftHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetLeftStick () * 10);

			}

		} else {
			
			leftHand.gameObject.GetComponent<Rigidbody2D> ().transform.position = leftHand.gameObject.GetComponent<Hand> ().GetPosition ();
		}
	}




	private void MoveRightHand(){

		if (rightHand.gameObject.GetComponent<Hand> ().IsHooked () == false) {

			if (GetRightStick ().magnitude > 0) {
				
				rightHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetRightStick () * 10);
			}
		} else {
			rightHand.gameObject.GetComponent<Rigidbody2D> ().transform.position = rightHand.gameObject.GetComponent<Hand> ().GetPosition ();
		}
	}
}
