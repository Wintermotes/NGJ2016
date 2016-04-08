using UnityEngine;
using System.Collections;

public class NewController : MonoBehaviour {

	//Prefix for controller type
	public string prefix;

	//Buttons
	private float stickHorizontal;
	private float stickVertical;
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
	}

	//Gets the input from the controller and maps it to variables
	private void GetInputButtonValues(){
		stickHorizontal = Input.GetAxis( prefix + "_Horizontal" );
		stickVertical = Input.GetAxis (prefix + "_Vertical");
		X = (Input.GetAxis (prefix + "_Jump") == 1) ? true : false;
		SQUARE = (Input.GetAxis (prefix + "_Push") == 1) ? true : false;
		TRIANGLE = (Input.GetAxis (prefix + "_Explode") == 1) ? true : false;
		ROUND = (Input.GetAxis (prefix + "_Throw") == 1) ? true : false;
	}
}