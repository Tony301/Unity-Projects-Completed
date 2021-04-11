using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveDevil : MonoBehaviour
{

    private Vector3 position;

    private Vector3 startTouchPosition, endTouchPosition;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(1.75f, 0f, 2f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.position = new Vector3(0f, 0f, 2f);
        }

    }
    
}