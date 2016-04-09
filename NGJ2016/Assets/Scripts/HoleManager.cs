using UnityEngine;
using System.Collections;

public class HoleManager : MonoBehaviour {

	private ArrayList holeList = new ArrayList ();
	public GameObject holeObject;

	public void CreateNewHole (){

		GameObject hole = Instantiate(holeObject) as GameObject; 
		hole.GetComponent<Hole>().Init();
		holeList.Add (hole);
	}

	private void UpdateHoleList(){}

	public ArrayList GetHoleList(){
		return holeList; 
	}
}
