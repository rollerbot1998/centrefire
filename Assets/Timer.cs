using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private float currentTime = 0f;
    private bool timerActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        //check if timer is active
        if (timerActive = true)
        {
            currentTime += Time.deltaTime;
        }

	}
}
