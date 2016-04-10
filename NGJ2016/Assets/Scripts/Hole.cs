using UnityEngine;
using System.Collections;

public class Hole : HoleManager {
    public Sprite[] buttonSprites;
    public Sprite[] objectSprites; 
    public enum Button { SQUARE, X, ROUND, TRIANGLE, PAD_LEFT, PAD_RIGHT, PAD_UP, PAD_DOWN };
    public float holeTime = 3.0f;

    private float startTime = 0.0f;
    private bool isCovered = false;
	private Vector2 position;

	private enum state {active, inactive, dead, invulnerable};
	private state playerState;
	private Button button;



    public void Init(Vector2 position){
		SetButton ();
		SetPosition (position);
	}


	/**
	 * Returns true if the holes button is pressed
	 * 
	 */
	private bool IsCorrectButtonPressed(PlayerController controller){

		bool buttonPressed = false;

		switch (this.button) {
			case Button.TRIANGLE:
				buttonPressed = controller.IsTrianglePressed ();
				break;
			case Button.X:
				buttonPressed = controller.IsXPressed ();
				break;
			case Button.ROUND:
				buttonPressed = controller.IsRoundPressed ();
				break;
			case Button.SQUARE:
				buttonPressed = controller.IsSquarePressed ();
				break;
			case Button.PAD_DOWN:
				buttonPressed = controller.IsPadDownPressed ();
				break;
			case Button.PAD_UP:
				buttonPressed = controller.IsPadUpPressed ();
				break;
			case Button.PAD_LEFT:
				buttonPressed = controller.IsPadLeftPressed ();
				break;
			case Button.PAD_RIGHT:
				buttonPressed = controller.IsPadRightPressed ();
				break;
		}

		return buttonPressed;
	}


	void OnTriggerStay2D(Collider2D col){

		string tag = col.GetComponent<Transform> ().tag;
		PlayerController controller = col.GetComponentInParent<PlayerController> ();


		string leftHandTag = controller.prefix + "_LeftHand";
		string rightHandTag = controller.prefix + "_RightHand";

		//Check if player hand
		if (tag == leftHandTag || tag == rightHandTag) {

			Hand hand = col.GetComponentInChildren<Hand> ();

			//bool button = controller.GetTriangle ();
			bool button = IsCorrectButtonPressed(controller);

			//Check if hole is covered
			if (this.isCovered == false) {

				//Check if button input = correct
				if (button == true) {
                    float startTime = Time.fixedTime;
                    Debug.Log("Start time set to: " + startTime);

                    //Update hand plug
                    hand.SetIsHooked(true);

					//Update hole isCovered
					this.isCovered = true;
				}
			}

			if (button == true) { //STAY
				
				//Keep hand position to hole
				hand.SetPosition (this.transform.position);

                // Begin timer
                
                float timeDifference = Time.time - startTime;
                Debug.Log("startTime" + startTime + ", Time.time: " + " , timeDifference" + timeDifference);

                // Check timer
                if (timeDifference < holeTime)
                {

                    Debug.Log("Chanelled for 3.0 seconds");
                }
            } else { //RELEASE
				
				//Update hole isCovered
				this.isCovered = false;

				//Update hand plug
				hand.SetIsHooked(false);
			}
		}
	}


	public void SetPosition(Vector2 position){
		this.transform.position = position;
	}

	public Vector2 GetPosition(){
		return this.transform.position;
	}

	/**
	 * Assigns a random button
	 */
	private void SetButton(){
        int buttonValue = Random.Range(0, 4);
        Sprite s = GetComponent<SpriteRenderer>().sprite = buttonSprites[buttonValue];
        button = (Button)buttonValue;
        
	}
		
	public bool IsCovered(){
		return this.isCovered;
	}


}
