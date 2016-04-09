using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	Vector3 scale = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<RectTransform> ().localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		//Rescale ();
		
	}



	public IEnumerator Rescale(){

		int maxFrames = 15;

		for (int frame = 0; frame < maxFrames; frame++) {

			float scaler = 1 / (float)maxFrames;
			scale =  scale + new Vector3 (scaler,scaler, scaler);

			//scale = new Vector3(0.5f, 0.5f, 0.5f);
			this.gameObject.GetComponent<RectTransform> ().localScale = scale;
			yield return null;
		}
	}
}
