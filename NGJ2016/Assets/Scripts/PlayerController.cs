using UnityEngine;
using System.Collections;

public class PlayerController : NewController {

//	GameObject leftHand;
//	GameObject rightHand;

	// Use this for initialization
	void Start () {
		Debug.Log ("Player " + prefix);

//		int children = transform.childCount;
//		for (int i = 0; i < children; ++i) {
//			Transform child = transform.GetChild (i);
//			Debug.Log ("Tag = " + child.tag);
//			if (child.tag == "LeftHand") {
//				
//				leftHand = child;
//			}
//			if (child.tag == "RightHand")
//				rightHand = child;
//
//		}
//
//		print("leftHand:  " + leftHand);
//		print("rightHand:  " + rightHand);
			
	}
	
	// Update is called once per frame
	void Update () {

		if (GetLeftStick ().magnitude > 0) {
			GameObject leftHand = GameObject.FindGameObjectWithTag (prefix + "_LeftHand");
			leftHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetLeftStick () * 10);
		}

		if (GetRightStick ().magnitude > 0) {
			GameObject rightHand = GameObject.FindGameObjectWithTag (prefix + "_RightHand");
			rightHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetRightStick () * 10);
		}

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Add force");
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10.0f);
        }
	}
}
