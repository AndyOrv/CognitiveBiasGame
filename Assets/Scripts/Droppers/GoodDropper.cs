using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Good version of the Dropper class, allowing for doors present to be opened when filled a ceratin amount
 */


public class GoodDropper : Dropper
{
    [SerializeField] int BadTally; //tally for bad door
    [SerializeField] int GoodTally; //tally for good door

    [SerializeField] GameObject badDoorTrig;
    [SerializeField] GameObject goodDoorTrig;

    private void Start()
    {
        badDoorTrig.SetActive(false);
        goodDoorTrig.SetActive(false);
    }

    private void Update()
    {
        if (count >= BadTally)
        {
            badDoorTrig.SetActive(true);
        }
        if (count >= GoodTally)
        {
            goodDoorTrig.SetActive(true);
        }
    }
}
