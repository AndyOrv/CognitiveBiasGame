using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Simple trigger for killing the player on collision with object
 */

public class KillZone : MonoBehaviour
{

    private GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.tag == "Player")
        {

            player.GetComponent<PlayerController>().killPlayer();
        }
    }
}
