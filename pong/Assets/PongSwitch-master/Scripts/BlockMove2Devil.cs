using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockMove2Devil : MonoBehaviour
{

    

    // Update is called once per frame
    void Update()
    {
       
                if (Input.GetMouseButtonDown(0))
                {
                    transform.position = new Vector3(-1.75f,0f,2f);
                }
               
                if (Input.GetMouseButtonUp(0))
                {
                    transform.position = new Vector3(0f,0f,2f);
                }
                
            }

            
        }

    

