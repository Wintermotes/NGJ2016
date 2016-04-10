using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private float width = 12f;
	private float height = 6f;

	//The 'energy' bar
	private float oxygenCounter;
	private float startOxygen = 10000;


	private float timer = 0;

	//Seconds passed in the level
	private int sessionTimer = 0;
	private int passedSessionTime = 0;

	//The time between new holes appear
	private float waitForHole = 5;

	private int numPlayers = 3;
	public GameObject[] players = new GameObject[3];

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

		oxygenCounter = startOxygen;

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
			if (prevGameState != gameState)
				passedSessionTime = Mathf.FloorToInt(Time.fixedTime);
				
			//Debug.Log ("passedSessionTime = " + passedSessionTime);
			sessionTimer = Mathf.FloorToInt(Time.fixedTime) - passedSessionTime;
			Transform gameTimer = UI.transform.Find ("Timer");
			gameTimer.GetComponent<Timer> ().UpdateTime (sessionTimer);

			if (Time.fixedTime - timer > waitForHole) {
				hm.CreateNewHole ();
				//Update timer
				timer = Time.fixedTime;
			}

			DecreaseOxygen ();


			if(GetOxygenPercentage() == 10){
				
				for(int player = 0; player < numPlayers; player++){
					Debug.Log ("Bloooooood");
					players[player].GetComponent<PlayerController>().CoughBlood(); 
				}
			}


			if (oxygenCounter < 0)
				gameState = GameState.gameOver;
		}

		//IF GAMEOVER
		if(gameState == GameState.gameOver){

			if (prevGameState != gameState) {
				Transform gameOver = UI.transform.Find ("Game Over");
				StartCoroutine (gameOver.GetComponent<GameOver> ().Rescale ());
			}


		}

		//Update prevState
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

		return lostOxygen;
	}


	public float GetTimer(){
		return this.timer;
	}

	public float GetOxygenCounter(){
		return this.oxygenCounter;
	}

	public int GetOxygenPercentage(){
		int percentLeft = Mathf.FloorToInt(oxygenCounter / startOxygen * 100);

		return percentLeft;
	}

	public void RestartGame(){
		if(gameState == GameState.gameOver)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public int GetPassedSessionTime(){
		return this.passedSessionTime;
	}

}
