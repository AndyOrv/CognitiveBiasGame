using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Attatchment to droppers which will set which dropper to play sounds for when first item is placed
 */

public class BellSound : MonoBehaviour
{
    [SerializeField] BellSound[] otherzones;
  
    public bool theOne = false;
    private bool othrFound = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!othrFound)
        {
            for(int i = 0; i < otherzones.Length; i++)
            {
                if(otherzones[i].theOne == true)
                {
                    othrFound = true;
                    break;
                }
            }
            if (!othrFound)
            {
                theOne = true;
            }
        }
        if (theOne)
        {
            
            FindObjectOfType<AudioManager>().Play("Correct");
            
        }
    }
}
