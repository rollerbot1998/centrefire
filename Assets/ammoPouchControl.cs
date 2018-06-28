using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPouchControl : MonoBehaviour {

    public GameObject camara;
    public Vector3 pouchTransformHeight;
    public Vector3 pouchTransformSide;
    private Vector3 camaraPos = new Vector3(1, 1, 1);
    private Quaternion camaraRotation;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        
        
        //get current position
        camaraPos = camara.transform.position;
        camaraRotation = camara.transform.rotation;
        //reduce y axis to be below player
        transform.position = camaraPos + pouchTransformHeight;
        
        //move out
        transform.position = transform.position + pouchTransformSide;

        

    }
}
