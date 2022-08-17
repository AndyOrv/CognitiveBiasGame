using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellSound : MonoBehaviour
{
    public BellSound[] otherzones;
  

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
            Debug.Log("the one");
            FindObjectOfType<AudioManager>().Play("Correct");
            
        }
        else
        {
            Debug.Log("not the one");
        }
    }
}
