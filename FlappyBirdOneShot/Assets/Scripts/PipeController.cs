using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour 
{
    public float speed = -0.025f;
    public float xBound = -20f;
    public float xRestart = 20f;
    public float yVariation = 2f;

    private float yStart;

    public void Start()
    {
        yStart = transform.position.y;

        Vector3 newPosition = GetComponent<Transform>().position;
        newPosition.y = yStart + Random.Range(-yVariation, yVariation);
        GetComponent<Transform>().position = newPosition;
    }

    // Update is called once per frame
    void Update () 
    {
        Vector3 newPosition = GetComponent<Transform>().position;

        newPosition.x += speed;

        if( newPosition.x < xBound )
        {
            newPosition.x = xRestart;

            //***** Extra content! *****
            newPosition.y = yStart + Random.Range(-yVariation, yVariation);
        }

        GetComponent<Transform>().position = newPosition;
    }
}
