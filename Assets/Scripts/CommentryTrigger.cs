using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Code for playing and stopping commentry audio is player is within a certain distance from commentry ball via a trigger
 */

public class CommentryTrigger : MonoBehaviour
{
    public string commentry;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play(commentry);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Stop(commentry);
        }
    }

}
