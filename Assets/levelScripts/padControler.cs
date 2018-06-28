using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class padControler : MonoBehaviour {

    //spawn variables
    public int numberOfEnemys;
    public float timeBettwenSpawnMin;
    public float timeBettwenSpawnMax;
    public float spawnLocationVariataion;
    public bool active;
    public GameObject enemyObject;
    public int numberOfSpawnPoints;
    public int delayToStartSpawn;


    private int childrenAtStart;

    private float spawnTimer;

    public bool complete = false;

    private int enemysAlive = 0;





    // Use this for initialization
    void Start () {

        //set initial spawn timer so player has time to move to new area
        spawnTimer = delayToStartSpawn;

        //get children at start
        childrenAtStart = transform.childCount;

    }
	
	// Update is called once per frame
	void Update () {
		
        //check if the section is active
        if (active == true)
        {

            //check timer
            if (spawnTimer <= 0)
            {
                //check remaining enemys
                if (numberOfEnemys != 0)
                {

                    SpawnEnemy();
                    Debug.Log("enemyspawned");

                }
            }

            //decrease timer
            spawnTimer -= Time.deltaTime;

            //check if section complete
            CompleteCheck();

        }


	}

    void Activate()
    {
        active = true;

        Unlock();
    }

    void Unlock()
    {
        //unlock tp pad
    }

    void Lock()
    {
        //lock tp pad
    }

    void SpawnEnemy()
    {

        //get random number for spawn point
        int point = Random.Range(0, numberOfSpawnPoints);

        //get spawn game object
        Transform thisSpawn = this.gameObject.transform.GetChild(point);

        //spawn at spawn point
        // Create the Bullet from the Bullet Prefab
        var enemy = (GameObject)Instantiate(
            enemyObject,
            thisSpawn.position,
           thisSpawn.rotation);

        //set enemy parent to this pad
        enemy.transform.parent = gameObject.transform;

        //add to alive
        enemysAlive += 1;

        //remove from pool
        numberOfEnemys -= 1;

        //reset spawn timer
        spawnTimer = Random.Range(timeBettwenSpawnMin, timeBettwenSpawnMax);
    }

    void CheckEnemysAlive()
    {
        //check if any enemys are alive
        enemysAlive = transform.childCount - childrenAtStart;

       

    }

    void CompleteCheck ()
    {
        //check enemys alive
        CheckEnemysAlive();

        if (enemysAlive == 0 && numberOfEnemys == 0)
        {
            complete = true;
        }
    }

    
}
