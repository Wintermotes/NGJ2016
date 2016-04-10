using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {

	//public float speed = -0.0005f;

	public Vector3 speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Move object
		Vector3 position = this.gameObject.transform.position;
		position += speed;
		this.gameObject.transform.position = position;
	}
}
