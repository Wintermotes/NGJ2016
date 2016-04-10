using UnityEngine;
using System.Collections;

public class splashScript : MonoBehaviour {
    GameObject bus; 

    void Start()
    {
        bus = GameObject.Find("BusOutside");
    }
	
	void Update () {
        if (Input.anyKey)
        {
            bus.GetComponent<Animator>().SetInteger("NewInt", 1);
            StartCoroutine(switchScene());
        }
	}

    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(10.0f);

        Application.LoadLevel(1);
    }
}
