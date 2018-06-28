using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullMagHold : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //make it be in hand
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;

        //move to make a better fit
        transform.localPosition = new Vector3(-0.1f, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
