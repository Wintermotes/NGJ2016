﻿using UnityEngine;
using System.Collections;

public class Hole : HoleManager {
    public Sprite[] buttonSprites;
    public Sprite[] objectSprites;
    public AudioClip[] holeClips;
    public AudioClip[] repairClips;
    public AudioClip holeClosedClip;
    public enum Button { SQUARE, X, ROUND, TRIANGLE, PAD_LEFT, PAD_RIGHT, PAD_UP, PAD_DOWN };
    private float holeTime = 10.0f;

    private float startTime = 0.0f;
    private bool isCovered = false;
	private Vector2 position;

	private enum state {active, inactive, dead, invulnerable};
	private state playerState;
	private Button button;

    private bool hasPlayed = false; 

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

				//Check if buttone input = correct
				if (button == true) {

					//Set startTime
                    startTime = Time.fixedTime;

                    //Update hand plug
                    hand.SetIsHooked(true);

                    //Update sprite 
//                    if(tag == controller.prefix + "_LeftHand")
//                    {
//						Debug.Log ("Calling change hand with: " + col.gameObject);
//                        controller.changeHandSprite(col.gameObject, true);
//                    }


                    //Update hole isCovered
                    this.isCovered = true;

                    //Play repair sound and stop hole sound 
                    PlaySound(repairClips[Random.Range(0, repairClips.Length)]);

                }
			}

			if (button == true) { //STAY
				
				//Keep hand position to hole
				hand.SetPosition (this.transform.position);

                //get time difference
                float timeDifference = Time.fixedTime - startTime;

                // Check timer
                if (timeDifference > holeTime)
				{

					Debug.Log ("Hola times is up");
                    // Set sprite
                    GetComponent<SpriteRenderer>().sprite = objectSprites[Random.Range(0, objectSprites.Length)];

                    // Set internal variables
                    this.isCovered = true;
                    hand.SetIsHooked(false);

                    // Play sound
                    PlaySound(holeClosedClip); 
                    return; 
                }
            } else { //RELEASE
				
				//Update hole isCovered
				this.isCovered = false;

				//Update hand plug
				hand.SetIsHooked(false);

                // Replay the wind sound 
                PlaySound(holeClips[Random.Range(0, holeClips.Length)]);

                // Change sprite back
                //controller.changeHandSprite(col.gameObject, false);
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
        int buttonValue = Random.Range(0, 7);
        button = (Button)buttonValue;

        GetComponent<SpriteRenderer>().sprite = buttonSprites[buttonValue];
        PlaySound(holeClips[Random.Range(0, holeClips.Length)]); 
    }
	
    private void PlaySound(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip; 
        GetComponent<AudioSource>().Play();
    }
    	
	public bool IsCovered(){
		return this.isCovered;
	}


}
