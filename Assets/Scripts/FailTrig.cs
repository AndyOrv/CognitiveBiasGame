using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            //Debug.Log(postion);
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

            //if (!positions[i].Equals(PuzzleTriggers[i].transform.position))
            //if (!(positions[i].x == PuzzleTriggers[i].transform.position.x
             //  && positions[i].z == PuzzleTriggers[i].transform.position.z))
             if(!(PosLeeWay(positions[i], PuzzleTriggers[i].transform.position)))
            {
                return false; 
            }
        }
        Debug.Log("CORRECT!");
        return true;
    }

    
    private bool PosLeeWay(Vector3 find, Vector3 within)//as cube doesnt spin perfect method impleneted to provide some leeway on trigger postion
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
