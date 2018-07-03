using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    float shotTimer = 5;
    int bulletSpeed = 5;
    

    Transform player;
    Transform firePoint;


	// Use this for initialization
	void Start () {

        //get player referance
        player = GameObject.FindWithTag("Player").transform;

        //get fire point referance
        firePoint = transform.Find("firePoint");
    }
	
	// Update is called once per frame
	void Update () {
		if (shotTimer <= 0)
        {
            //shoot
            Shoot();

            //reset shot timer
            shotTimer = Random.Range(1f, 4f);
        }

        //reduce timer
        shotTimer -= Time.deltaTime;

    }

   void Shoot()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            Resources.Load("prefabs/gunsAndAmmo/bulletPrefab") as GameObject,
            firePoint.position,
           firePoint.rotation);

        //rotate bullet towards player
        bullet.transform.LookAt(player);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }

}
