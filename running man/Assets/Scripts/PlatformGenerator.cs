using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatforms;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    public GameObject[] thePlatform;

    private float[] platformWidths;




    // Start is called before the first frame update
    void Start()
    {
        // platformWidth = thePlatforms.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[thePlatform.Length];

        for(int i = 0; i < thePlatform.Length; i++)
        {
            platformWidths[i] = thePlatform[i].GetComponent<BoxCollider2D>().size.x;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            platformSelector = Random.Range(0, thePlatform.Length);

            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(/*thePlatforms*/thePlatform[platformSelector], transform.position, transform.rotation);

           

        }


    }
}
