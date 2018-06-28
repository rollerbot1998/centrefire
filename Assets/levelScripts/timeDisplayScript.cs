using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeDisplayScript : MonoBehaviour {

    public float time;
    public Text textReferance;


    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        textReferance.text = time.ToString();

    }
}
