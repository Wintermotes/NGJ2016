using UnityEngine;
using System.Collections;

public class BusBoundaries : MonoBehaviour {


	public float bounceEffect = 100.0f; 

	void OnTriggerEnter2D(Collider2D other)
	{
		Vector2 forceVec = -other.GetComponent<Rigidbody2D>().velocity * bounceEffect;
		other.GetComponent<Rigidbody2D>().AddForce(forceVec);
	}
}
