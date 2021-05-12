using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Material CheckPointAfterMaterial;

    private MeshRenderer meshRenderer;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
            meshRenderer.material = CheckPointAfterMaterial;
        }
    }
}
