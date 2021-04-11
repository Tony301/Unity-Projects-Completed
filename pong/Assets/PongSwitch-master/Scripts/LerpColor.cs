using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    MeshRenderer cubemeshRender;
    [SerializeField] [Range(0f, 1f)] float lerpTime;

    [SerializeField] Color[] myColor;

    int colorIndex = 0;
    float t = 0f;

    int len;
    // Start is called before the first frame update
    void Start()
    {
        cubemeshRender = GetComponent<MeshRenderer>();
        len = myColor.Length;
    }

    // Update is called once per frame
    void Update()
    {
        cubemeshRender.material.color = Color.Lerp(cubemeshRender.material.color, myColor[colorIndex], lerpTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if(t>.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    
    }
}
