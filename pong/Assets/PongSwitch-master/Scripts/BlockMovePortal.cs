using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovePortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(-1.39f, 0.711f, -0.56f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.position = new Vector3(-0.21f, 0.711f, -0.56f);
        }

    }


}