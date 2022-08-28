using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Bad dropper varient class to allow for player death if bad tubes filled
 */


public class BadDropper : Dropper
{
    [SerializeField] int tally;

    private GameObject player;

    private void Update()
    {
        if (count >= tally)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            FindObjectOfType<AudioManager>().Play("level2E");
            killPlayer();
        }
    }
    
    void killPlayer()
    {
        FindObjectOfType<AudioManager>().Play("level2E");
        player.GetComponent<PlayerController>().killPlayer();
    }
}

