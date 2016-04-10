using UnityEngine;
using System.Collections;

public class HoleManager : MonoBehaviour {

	private ArrayList holeList = new ArrayList ();
	private float minHoleDistance = 5;
	private float width;
	private float height;

	//The hole game object
	public GameObject holeObject;


	public void SetWidth(float w){
		this.width = w;
	}
	public void SetHeight(float h){
		this.height = h;
	}

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
		//Debug.Log ("checkPosition() Running and I count " + holeList.Count + " holes");

		Vector2 position = new Vector2(0,0);
		float diff = 0;

		bool toClose = true;

		int index = 0;
		while (toClose == true && index < 10) {

			toClose = false;

			position = GetRandomPositionWithinPlayableArea ();

			foreach (GameObject h in holeList) {

				Vector2 otherPosition = h.GetComponent<Hole> ().GetPosition ();
				float distance = Mathf.Abs ((otherPosition - position).magnitude);

				if (distance < minHoleDistance) {
					toClose = true;
				}
			}
			index++;
			minHoleDistance--;
		}

		if(toClose == true)
			position = GetRandomPositionWithinPlayableArea ();

		//Reset MinHoleDistance for next hole
		minHoleDistance = 5;

		return position;
	}


	private Vector2 GetRandomPositionWithinPlayableArea(){
		return new Vector2 (Random.Range (-width/2, width/2), Random.Range (-height/2, height/2));
	}
}
