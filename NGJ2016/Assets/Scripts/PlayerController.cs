using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Add force");
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10.0f);
        }
	}
}
