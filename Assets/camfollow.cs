using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour {
    [Tooltip("The object that the camera will follow.  ")]
    public GameObject target;
    [Tooltip("Float value representing the height of the camera from the targeted object.")]
    public float camera_height;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        transform.SetPositionAndRotation(new Vector3(target.transform.position.x, camera_height, target.transform.position.z),Quaternion.Euler(90,0,0));

	}
}
