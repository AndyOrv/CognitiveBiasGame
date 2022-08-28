using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: simple class to swap the material and object when needed, currently only needed for 1 change but can be easily modified to work with any numbers of materials
 */

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] Material[] material;
    Renderer rend;



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = material[0];
    }

    private void OnCollisionEnter(Collision collision)
    {
        rend.sharedMaterial = material[1];
    }

}
