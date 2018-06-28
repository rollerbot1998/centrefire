using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {

    public GameObject DefaultBulletHit;
    public GameObject DefaultBloodHit;
    public Vector3 ParticleAngleAdjust;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    

    //do collision checks
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            DefaultBloodHit = Instantiate(DefaultBloodHit, transform.position, Quaternion.Inverse(Quaternion.FromToRotation(transform.up, transform.forward))) as GameObject;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }
        else
        {


            DefaultBulletHit = Instantiate(DefaultBulletHit, transform.position, Quaternion.Inverse(Quaternion.FromToRotation(transform.up,transform.forward))) as GameObject;
            Destroy(gameObject);
            return;
        }


        
    }

}
