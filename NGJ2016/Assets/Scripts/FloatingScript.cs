using UnityEngine;
using System.Collections;

public class FloatingScript : MonoBehaviour {

    public float minXOffset = 10.0f;
    public float maxXOffset = 25.0f;
    public float minYOffset = 10.0f;
    public float maxYOffset = 25.0f; 

    void Start()
    {
        Vector2 startPush = new Vector2(Random.Range(minXOffset, maxXOffset), Random.Range(minYOffset, maxYOffset));
        GetComponent<Rigidbody2D>().AddForce(startPush);
        ArrayList check = new ArrayList();
    }
}
