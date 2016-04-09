using UnityEngine;
using System.Collections;

public class HoleManager : MonoBehaviour {

	private ArrayList holeList = new ArrayList ();
	private float minHoleDistance = 2;

	//The hole game object
	public GameObject holeObject;

	public void CreateNewHole (){

		GameObject hole = Instantiate(holeObject) as GameObject;
		hole.GetComponent<Hole>().Init(GetSecludedPosition ());
		//hole.GetComponent<Hole> ().SetPosition (GetSecludedPosition ());
		holeList.Add (hole);

	}

	public void removeHole (){}

	private void UpdateHoleList(){}


	public ArrayList GetHoleList(){
		return holeList; 
	}

	public Hole GetHoleFromList(int index){
		return (Hole)holeList [index];
	}


	/**
	 * Finds a position
	 */
	public Vector2 GetSecludedPosition(){
		Debug.Log ("checkPosition() Running and I count " + holeList.Count + " holes");

		Vector2 position = new Vector2(0,0);
		float diff = 0;

		bool toClose = true;

		while (toClose == true) {

			toClose = false;
			position = new Vector2 (Random.Range (-5f, 5f), Random.Range (-5f, 5f));
			Debug.Log("Testing pos @" + position);

			foreach (GameObject h in holeList) {

				Vector2 otherPosition = h.GetComponent<Hole> ().GetPosition ();
				float distance = Mathf.Abs ((otherPosition - position).magnitude);

				if (distance < minHoleDistance) {
					toClose = true;
				}
			}
		}

		Debug.Log ("Assigning position @" + position);

		return position;
	}
		
}
