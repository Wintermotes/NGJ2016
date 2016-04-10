using UnityEngine;
using System.Collections;

public class PlayerController : NewController {

    public AudioClip[] coughSounds;
    public GameObject bloodParticles;
	GameObject leftHand;
	GameObject rightHand;

	float handMovementSpeed = 6f;
	

	// Use this for initialization
	void Start () {
		leftHand = GameObject.FindGameObjectWithTag (prefix + "_LeftHand");
		rightHand = GameObject.FindGameObjectWithTag (prefix + "_RightHand");
	}
	
	// Update is called once per frame
	void Update () {
		
		MoveLeftHand ();

		MoveRightHand ();

	}

	/**
	 * Moves the left hand with the left stick, if it's not hooked
	 * else it keeps the position of the attached hole
	 */
	private void MoveLeftHand(){
		if (leftHand.gameObject.GetComponent<Hand> ().IsHooked () == false) {
			
			if (GetLeftStick ().magnitude > 0) {
				leftHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetLeftStick () * handMovementSpeed);
			}
		} else {
			KeepLeftHandAtHole ();
		}
	}

	private void KeepLeftHandAtHole(){
		leftHand.gameObject.GetComponent<Rigidbody2D> ().transform.position = leftHand.gameObject.GetComponent<Hand> ().GetPosition ();
	}



	/**
	 * Moves the right hand with the right stick, if it's not hooked
	 * else it keeps the position of the attached hole
	 */
	private void MoveRightHand(){
		if (rightHand.gameObject.GetComponent<Hand> ().IsHooked () == false) {
			if (GetRightStick ().magnitude > 0) {
				rightHand.gameObject.GetComponent<Rigidbody2D> ().AddForce (GetRightStick () * handMovementSpeed);
			}
		} else {
			KeepRightHandAtHole ();
		}
	}

	private void KeepRightHandAtHole(){
		rightHand.gameObject.GetComponent<Rigidbody2D> ().transform.position = rightHand.gameObject.GetComponent<Hand> ().GetPosition ();
	}

    public void CoughBlood()
    {
        // PUT THIS IN LEVEL_MANAGER: 
        //  GameObject someplayer.GetComponent<PlayerController>().CoughBlood(); 
        GetComponentInChildren<ParticleSystem>().Play();
        StartCoroutine(coughBloodSounds());

    }

    IEnumerator coughBloodSounds ()
    {
        AudioSource source = GetComponent<AudioSource>();

        source.clip = coughSounds[Random.Range(0, coughSounds.Length)];
        source.Play();
        yield return new WaitForSeconds(1.0f);

        source.clip = coughSounds[Random.Range(0, coughSounds.Length)];
        source.Play();
        yield return new WaitForSeconds(1.0f);

        source.clip = coughSounds[Random.Range(0, coughSounds.Length)];
        source.Play();
        yield return new WaitForSeconds(1.0f);

    }
}
