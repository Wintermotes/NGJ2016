using UnityEngine;
using System.Collections;

public class HoleVFX : MonoBehaviour {

    public GameObject particleRenderer; 
    
    public void CreateFire(Vector3 position)
    {
        position.z = 0.0f;
        Instantiate(particleRenderer, position, Quaternion.identity);
    }
}
