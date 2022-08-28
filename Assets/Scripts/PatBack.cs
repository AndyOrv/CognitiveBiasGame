using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Present in level 3 allowing for palyer pat back Once via trigger point
 */

public class PatBack : MonoBehaviour
{
    private GameObject player;
    private bool been = false;

    void OnTriggerEnter(Collider cube)
    {
        if (!been)
        {
            // whenever anything enters the trigger, open the door
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().CanPat = true;
            FindObjectOfType<AudioManager>().Play("level3B");
            
            been = true;
        }

    }
}
