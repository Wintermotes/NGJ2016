using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	public int button;
	public Vector2 position;

	private bool isHooked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector2 GetPosition(){
		return this.position;
	}

	public void SetPosition(Vector2 pos){
		this.position = pos;
	}


	public bool IsHooked(){
		return isHooked;
	}

	public void SetIsHooked(bool isHooked){
		this.isHooked = isHooked;
	}
}
