using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove2 : MonoBehaviour
{

    Vector3 Left = new Vector3(-5f, -4f, -1.45f);
    Vector3 Right = new Vector3(-3f, -4f, -1.45f);
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)))
        {
            this.transform.position = new Vector3(-5f, -4f, -1.45f);
        }
       if((Input.GetMouseButtonUp(0)))
        {
            this.transform.position = new Vector3(-3f, -4f, -1.45f);
        }
    }
}
