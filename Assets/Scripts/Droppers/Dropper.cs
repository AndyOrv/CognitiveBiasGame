using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Dropper class for puzzel on level two allows for objects to be placed within and tracked
 */


public class Dropper : MonoBehaviour
{
    public int count = 0;

    [SerializeField] Material changeColour;
    [SerializeField] GameObject[] marks;

    private string[] drops = new string[] { "Drop1", "Drop2", "Drop3", "Drop4", "Drop5","Drop6" }; //narrator voice lines to be played randomly when object is dropped
    int index;
    

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "GameCube")
        {
            ColourChange(marks[count]);
            count++;
            //index to select voice at random
            index = Random.Range(0, drops.Length);

            FindObjectOfType<AudioManager>().Play(drops[index]);

        }
    }

    private void ColourChange(GameObject mar)
    {
        mar.GetComponent<Renderer>().sharedMaterial = changeColour;
    }
}
