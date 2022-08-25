using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatBack : MonoBehaviour
{
    private GameObject player;

    void OnTriggerEnter(Collider cube)
    {
        // whenever anything enters the trigger, open the door
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().CanPat = true;
    }
}
