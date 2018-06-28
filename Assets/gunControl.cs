using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class gunControl : MonoBehaviour {

    // Use this for initialization
    public GameObject bulletPrefab;
    public GameObject Magazine;
    public GameObject CasingPrefab;
    public Transform bulletSpawn;
    public Transform MagLocation;
    public Transform MagDropLocation;
    public Transform CasingSpawn;
    public float slideDistance;
    public AudioClip shot;
    public AudioClip slideBack;
    public AudioClip slideForward;

    //timer default
    private float TimeBettwenShots = .0f;
    //current timer
    private float shotTimer = 0;
    //Bullet cull time
    private float bulletCullTime = 2;
    //Bullet speed
    private int bulletSpeed = 50;
    //mag size
    private int magSize = 7;
    //number of shots left
    private int shotsRemaining ;
    //mag cull time
    private int magCullTime = 5;
    //if mag is present
    private bool magInGun = true;
    //slide referance
    private Transform slide;
    //audio saurce
    AudioSource audioSource;




    private Hand handScript;

    void Start()
    {
         handScript = GetComponent<Hand>();
        shotsRemaining = magSize;
        slide = gameObject.transform.Find("pistol/slide");
        audioSource = GetComponent<AudioSource>();
    }




    // Update is called once per frame
    void Update () {
        //check if mag dropping
        if (Input.GetButtonDown("Fire1") && magInGun == true)
        {
            dropMag();
        }


            if (handScript.controller.GetHairTriggerDown())
     {
            //check timer
            if (shotTimer <= 0)
            {
                //check mag
                if (shotsRemaining > 0)
                {
                    Fire();

                    //reset timer
                    shotTimer = TimeBettwenShots;

                    magCheck();
                }
            }

                      

     }
        
    //handle timers
        if (shotTimer > 0)
        {
            shotTimer = shotTimer - Time.deltaTime;

        }

        if (magInGun == false)
        {
                      

            //chech mag collision
            Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

            foreach (Collider col in cols)
            {
                if (col.transform.tag == "ammo")
                {
                    newMag();

                    Destroy(col.gameObject);

                    moveSlideForward();
                }
            }

            

            //delete array
            cols = null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "fullMag")
        {
            //check gun is empty
           if (magInGun == false)
            {
                newMag();

                Destroy(collision.gameObject);

                
            }
        }
    }


    void Fire()
    {
      // Create the Bullet from the Bullet Prefab
      var bullet = (GameObject)Instantiate(
          bulletPrefab,
          bulletSpawn.position,
         bulletSpawn.rotation);
    
     // Add velocity to the bullet
     bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // remove bullet from mag
        shotsRemaining -= 1;

      // Destroy the bullet after 2 seconds
        Destroy(bullet, bulletCullTime);

        //spawn casing
        spawnCasing();

        //play sound
        audioSource.PlayOneShot(shot, 1F);
    }

    //used to check if mag is at 0 and start timer
    void magCheck ()
    {
        if (shotsRemaining == 0)
        {
            dropMag();
        }

    }

    void dropMag ()
    {
        //spawn dropped mag
        // Create the Bullet from the Bullet Prefab
        var mag = (GameObject)Instantiate(
            Magazine,
            MagDropLocation.position,
           MagDropLocation.rotation);

        // Add velocity to the mag
        mag.GetComponent<Rigidbody>().velocity = mag.transform.forward * .5f;

        // Destroy the bullet after 2 seconds
        Destroy(mag, magCullTime);

        //change mag status
        magInGun = false;

        //set no shots left
        shotsRemaining = 0;

        //move slide back
        moveSlideBack();
    }



    void newMag ()
    {
        shotsRemaining = magSize;

        magInGun = true;
    }

    private void moveSlideBack()
    {
        slide.transform.localPosition = new Vector3(0,0,slideDistance);
        //play sound
        audioSource.PlayOneShot(slideBack, 0.4F);
    } 

    private void moveSlideForward ()
    {
        slide.transform.localPosition = new Vector3(0, 0, 0);
        //play sound
        audioSource.PlayOneShot(slideForward, 0.4F);
    }

    void spawnCasing()
    {
        // Create the Bullet from the Bullet Prefab
        var casing = (GameObject)Instantiate(
            CasingPrefab,
            CasingSpawn.position,
           CasingSpawn.rotation);

        // Add velocity to the bullet
        casing.GetComponent<Rigidbody>().velocity = casing.transform.forward * 1;

        // Destroy the casing after 2 seconds
        Destroy(casing, 2);
    }
}
