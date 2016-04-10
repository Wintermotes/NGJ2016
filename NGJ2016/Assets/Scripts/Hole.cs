using UnityEngine;
using System.Collections;

public class Hole : HoleManager {

	private bool isCovered = false;
	private Vector2 position;

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

	public void Init(Vector2 position){
		SetButton ();
		SetPosition (position);
		//checkPosition ();
	}


	void OnTriggerStay2D(Collider2D col){

		//Check if hole is covered
		if (this.isCovered == false) {

			Transform transform = col.GetComponent<Transform> ();
			PlayerController controller = col.GetComponentInParent<PlayerController> ();
			//Debug.Log ("Controller = " + controller.name);

			//Check if player
			if (transform.tag == controller.prefix + "_LeftHand") {


				bool button = controller.GetTriangle();

				Debug.Log ("Triangle is pressed = " + button);

				//Check if button input = correct
				if(button == true){

					//Update hand plug
					controller.leftHandIsHooked = true;

					//Set position
					controller.lefthandHolePosition = this.transform.position;

					//Update hole isCovered
					this.isCovered = true;
				}
			}

		}
	}


	public void SetPosition(Vector2 position){
		//position = new Vector2 (Random.Range (-5f, 5f), Random.Range (-5f, 5f));
		//GetSecludedPosition (position);

		this.transform.position = position;
	}

	public Vector2 GetPosition(){
		return this.transform.position;
	}

	/**
	 * Assigns a random button
	 */
	private void SetButton(){
		button = (Button)Random.Range(0, 7);
	}
		
	public bool IsCovered(){
		return this.isCovered;
	}


}
