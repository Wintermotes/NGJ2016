using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private float width = 12f;
	private float height = 6f;

	//The 'energy' bar
	private float oxygenCounter = 10000;
	private float startOxygen = 10000;

	//Seconds passed in the level
	private float timer = 0;

	//The time between new holes appear
	private float waitForHole = 5;

	private int numPlayers = 1;

	private HoleManager hm;

	GameObject UI;

	//The enum values for getting the state of the game
	private enum GameState { intro, playing, gameOver };
	private GameState gameState;
	private GameState prevGameState;


	// Use this for initialization
	void Start () {
		hm = this.gameObject.GetComponent<HoleManager> ();
		UI = GameObject.Find ("UI");

		timer = Time.fixedTime;

		gameState = GameState.intro;

		hm.SetWidth (width);
		hm.SetHeight (height);
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
				//Update timer
				timer = Time.fixedTime;
			}

			DecreaseOxygen ();

			if (oxygenCounter < 0)
				gameState = GameState.gameOver;
		}

		//IF GAMEOVER
		if(gameState == GameState.gameOver){

			if (prevGameState != gameState) {
				Transform go = UI.transform.Find ("Game Over");
				StartCoroutine (go.GetComponent<GameOver> ().Rescale ());
				Debug.Log ("Game over is = " + go);
			}
		}


		prevGameState = gameState;
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


	public float GetTimer(){
		return this.timer;
	}
}
