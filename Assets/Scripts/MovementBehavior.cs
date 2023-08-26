using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

    }
        public void MovementLoop(){
     
        print("Time: " + startTime);
    

        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        print("Dist: " + fractionOfJourney);

        if (fractionOfJourney >= 1){   
            startTime = Time.time;
            Transform holder = startMarker;
            startMarker = endMarker;
            endMarker = holder;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementLoop();
    }


}
