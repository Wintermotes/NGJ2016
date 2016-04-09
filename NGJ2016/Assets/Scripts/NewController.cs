using UnityEngine;
using System.Collections;

public class NewController : MonoBehaviour {

	//Prefix for controller type
	public string prefix;

	//Buttons
	private float stickLeftHorizontal;
	private float stickLeftVertical;
	private float stickRightHorizontal;
	private float stickRightVertical;

	private float padHorizontal;
	private float padVertical;

	private float L2;
	private float R2;
	private bool L2_pressed = false;
	private bool R2_pressed = false;

	private bool SQUARE;
	private bool X;
	private bool ROUND;
	private bool TRIANGLE;



	GameObject player;
	Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();
		player = this.gameObject;
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		GetInputButtonValues ();

		InverseHorizontalPadValues ();
		InverseHorizontalLeftStickValues ();
		InverseHorizontalRightStickValues ();
		NormalizeL2AndR2 ();

		//DebugButtons ();

	}


	//Gets the input from the controller and maps it to variables
	private void GetInputButtonValues(){

		stickLeftHorizontal = Input.GetAxis( prefix + "_LEFT_HORIZONTAL");
		stickLeftVertical = Input.GetAxis (prefix + "_LEFT_VERTICAL");
		stickRightHorizontal = Input.GetAxis( prefix + "_RIGHT_HORIZONTAL");
		stickRightVertical = Input.GetAxis (prefix + "_RIGHT_VERTICAL");

		X = (Input.GetAxis (prefix + "_X") == 1) ? true : false;
		SQUARE = (Input.GetAxis (prefix + "_SQUARE") == 1) ? true : false;
		TRIANGLE = (Input.GetAxis (prefix + "_TRIANGLE") == 1) ? true : false;
		ROUND = (Input.GetAxis (prefix + "_ROUND") == 1) ? true : false;

		padHorizontal = Input.GetAxis (prefix + "_PAD_HORIZONTAL");
		padVertical = Input.GetAxis (prefix + "_PAD_VERTICAL");

		L2 = Input.GetAxis (prefix + "_L2");
		R2 = Input.GetAxis (prefix + "_R2");

	}


	private void InverseHorizontalPadValues(){
		padVertical *= -1;
	}

	private void InverseHorizontalLeftStickValues(){
		stickLeftVertical *= -1;
	}

	private void InverseHorizontalRightStickValues(){
		stickRightVertical *= -1;
	}

	private void NormalizeL2AndR2(){

		//Set values to zero when not been pressed yet
		if (L2 > 0.5f)
			L2_pressed = true;
		if (R2 > 0.5f)
			R2_pressed = true;
		if (L2_pressed == false)
			L2 = -1;
		if (R2_pressed == false)
			R2 = -1;
		
		//Normalize between 0 and 1
		L2 = (L2 + 1) / 2;
		R2 = (R2 + 1) / 2;
	}


	private void DebugButtons(){
		if(stickLeftHorizontal != 0)
			Debug.Log (prefix + " stickLeftHorizontal = " + stickLeftHorizontal);
		if(stickLeftVertical != 0)
			Debug.Log (prefix + " stickLeftVertical = " + stickLeftVertical);
		if(stickRightHorizontal != 0)
			Debug.Log (prefix + " stickRightHorizontal = " + stickRightHorizontal);
		if(stickRightVertical != 0)
			Debug.Log (prefix + " stickRightVertical = " + stickRightVertical);

		if(X == true)
			Debug.Log (prefix + " X is pressed" + X);
		if(SQUARE == true)
			Debug.Log (prefix + " SQAURE is pressed" + SQUARE);
		
		if(TRIANGLE == true)
			Debug.Log (prefix + " TRIANGLE is pressed" + TRIANGLE);
		if(ROUND == true)
			Debug.Log (prefix +  " ROUND is pressed" + ROUND);
		if(padHorizontal != 0)
			Debug.Log (prefix + " padHorizontal is " + padHorizontal);
		if(padVertical != 0)
			Debug.Log (prefix + " padVertical is " + padVertical);

		if(L2 != 0)
			Debug.Log (prefix + " L2 is " + L2);
		if(R2 != 0)
			Debug.Log (prefix + " R2 is " + R2);
	}

	public Vector2 GetLeftStick(){
		return new Vector2 (stickLeftHorizontal, stickLeftVertical);
	}
	public Vector2 GetRightStick(){
		return new Vector2 (stickRightHorizontal, stickRightVertical);
	}

	public bool IsSquarePressed(){
		return this.SQUARE;
	}
	public bool IsXPressed(){
		return this.X;
	}
	public bool IsRoundPressed(){
		return this.ROUND;
	}
	public bool IsTrianglePressed(){
		return this.TRIANGLE;
	}
	public bool IsPadUpPressed(){
		if (padVertical == 1)
			return true;
		else
			return false;
	}
	public bool IsPadDownPressed(){
		if (padVertical == -1)
			return true;
		else
			return false;
	}
	public bool IsPadLeftPressed(){
		if (padHorizontal == -1)
			return true;
		else
			return false;
	}
	public bool IsPadRightPressed(){
		if (padHorizontal == 1)
			return true;
		else
			return false;
	}

}