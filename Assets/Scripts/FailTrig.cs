using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: This is for use on the puzzel in level 3 which has 3 spinnable cubes and 1 correct combination
 */


public class FailTrig : MonoBehaviour
{
    [SerializeField] GameObject doorTrigger;
    [SerializeField] GameObject killTrigger;
    [SerializeField] GameObject[] PuzzleTriggers;

    [SerializeField] Vector3[] positions;



    private void Start()
    {
        doorTrigger.SetActive(false);
        killTrigger.SetActive(false);


        positions = new Vector3[PuzzleTriggers.Length];

        //Fill postions list with the original positions of the puzzle triggers
        for (int i = 0; i < PuzzleTriggers.Length; i++)
        {
            

            Vector3 postion = PuzzleTriggers[i].transform.position;
            positions[i] = postion;
        }
    }

    private void OnMouseUpAsButton()
    {
        if (PuzzleCorrect())
        {
            doorTrigger.SetActive(true);
        }
        else
        {
            killTrigger.SetActive(true);
        }
    }

    private bool PuzzleCorrect() {
        for (int i = 0; i < PuzzleTriggers.Length; i++)
        {


             if(!(PosLeeWay(positions[i], PuzzleTriggers[i].transform.position)))
            {
                return false; 
            }
        }

        return true;
    }


    //as cube doesnt spin perfect method impleneted to provide some leeway on trigger postion
    private bool PosLeeWay(Vector3 find, Vector3 within)
    {
        float tempX;
        float tempZ;

        tempX = Mathf.Abs(find.x - within.x);
        tempZ = Mathf.Abs(find.z - within.z);

        if(tempX < 0.5 && tempZ < 0.5)
        {
            return true;
        }

        return false;
    }
    

}
