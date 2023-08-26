using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    //public Transform startMarker;
    //public Transform endMarker;
    Vector3 startMarker;
    [SerializeField] Vector3 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;


    void Start()
    {
        startTime = Time.time;
        startMarker = transform.position;
        endMarker = new Vector3(startMarker.x + endMarker.x, startMarker.y + endMarker.y, startMarker.z + endMarker.z);
        journeyLength = Vector3.Distance(startMarker, endMarker);

    }
        

    void Update()
    {
        MovementLoop();
    }

    public void MovementLoop()
    {

        print("Time: " + startTime);


        float distCovered = (Time.time - startTime) * speed; //velocidade média
        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
        print("Dist: " + fractionOfJourney);

        if (fractionOfJourney >= 1)
        {
            startTime = Time.time;
            Vector3 holder = startMarker;
            startMarker = endMarker;
            endMarker = holder;
        }
    }

}
