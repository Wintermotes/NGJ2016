using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//The 'energy' bar
	private float oxygenCounter = 1000;

	//Seconds passed in the level
	private float timer = 0;

	//The time between new holes appear
	private float waitForHole = 1;

	private int numPlayers = 1;

	private HoleManager hm;

	//The enum values for getting the state of the game
	private enum GameState { intro, playing, gameOver };
	private GameState gameState;


	// Use this for initialization
	void Start () {
		hm = this.gameObject.GetComponent<HoleManager> ();

		timer = Time.fixedTime;

		gameState = GameState.intro;
	}
	
	// Update is called once per frame
	void Update () {


		//IF INTRO
		if (gameState == GameState.intro) {
			gameState = GameState.playing;
		}

		//IF PLAYING
		if (gameState == GameState.playing) {
			if (Time.fixedTime - timer > waitForHole) {
				hm.CreateNewHole ();
				timer = Time.fixedTime;
			}

			DecreaseOxygen ();

			if (oxygenCounter < 0)
				gameState = GameState.gameOver;
		}

		//IF GAMEOVER
		if(gameState == GameState.gameOver){


		}

	}


	/**
	 * Decrease oxygenCounter by the oxygen loss count
	 */
	private void DecreaseOxygen(){
		oxygenCounter -= GetOxygenLossCount ();
	}
		
	/**
	 * Counts number of holes and finds how much oxygen is subtracted
	 */ 
	private float GetOxygenLossCount(){
		float lostOxygen = 0;

		foreach (GameObject h in hm.GetHoleList()) {
			if (h.GetComponent<Hole> ().IsCovered () == false) {
				lostOxygen += 1;
			}
		}

		//Debug.Log("OxygenCount = " + lostOxygen);

		return lostOxygen;
	}
}
