using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class levelController : MonoBehaviour {

    //used to control when the player can move to the next section, causing sections to become active as the game progresses.


    //variables
    private int numberOfPoints = 0;
    private int currentPoint = 0;
    private float currentTime = 0f;
    private bool timerActive = false;

    timeDisplayScript timescript;

    GameObject currentPad;
    GameObject timeDisplay;

    private padControler scriptAccess;




    


    // Use this for initialization
    void Start () {
        numberOfPoints = transform.childCount - 2;

        //find display object and set variable
        timeDisplay = GameObject.FindWithTag("timeDisplay");
        timescript = timeDisplay.GetComponent<timeDisplayScript>();

        //update child to start
        getNextChild();
    }
	
	// Update is called once per frame
	void Update () {

        //at start point
        if (currentPoint == 0)
        {
            
            if (scriptAccess.complete == true)
            {
                //deactivate old
                scriptAccess.active = false;
                currentPoint += 1;
                getNextChild();
                //activate new
                scriptAccess.active = true;
                //active timer once part 1 is complete
                timerActive = true;
            }


        }
        else if (currentPoint <= numberOfPoints)
        {

            if (scriptAccess.complete)
            {
                //deactivate old
                scriptAccess.active = false;
                currentPoint += 1;
                getNextChild();
                //activate new
                scriptAccess.active = true;
          
                
            }

        }
        else
        {
            //once all sections complete stop timer
            timerActive = false;



        }


        //run timer and update display
        if (timerActive == true)
        {
            currentTime += Time.deltaTime;
            timescript.time = currentTime;
        }



    }

    void getNextChild()
    {
       
        if (currentPoint == 0)
        {

            currentPad = GameObject.Find("startPoint");


        }
        else if (currentPoint <= numberOfPoints)
        {

            currentPad = GameObject.Find("TeleportArea (" + currentPoint + ")");
            
        }
        else
        {

            currentPad = GameObject.Find("endPoint");

        }

        //update script
        updateScriptAccess();
    }

    void updateScriptAccess()
    {
        scriptAccess = currentPad.GetComponent<padControler>();
    }

    
}
