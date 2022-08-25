using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDropper : Dropper
{
    [SerializeField] int tally;

    private GameObject player;

    private void Update()
    {
        if (count >= tally)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            killPlayer();
        }
    }

   // void Awake()
    //{
        //player = GameObject.FindGameObjectWithTag("Player");
    //}
    
    void killPlayer()
    {
        player.GetComponent<PlayerController>().killPlayer();
    }
}

