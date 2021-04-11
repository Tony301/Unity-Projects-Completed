using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Move : MonoBehaviour
{

    private NavMeshAgent nma = null;
    private GameObject[] RandomPoint;
    private int CurrentRandom;
   
   private void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        RandomPoint = GameObject.FindGameObjectsWithTag("RandomPoint");
        Debug.Log("RandomPoints=" + RandomPoint.Length.ToString());
    }

    // Update is called once per frame
    private void Update()
    {
       if(nma.hasPath==false)
        {
            CurrentRandom = Random.Range(0, RandomPoint.Length + 1);
            nma.SetDestination(RandomPoint[CurrentRandom].transform.position);
            Debug.Log("Moving to RandomPoint" + CurrentRandom.ToString());
        }
    }
    private void FixedUpdate()
    {
        
    }
}
