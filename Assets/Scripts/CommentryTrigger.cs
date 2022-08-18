using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
