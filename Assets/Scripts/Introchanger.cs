using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
-- Author: Andrew Orvis
-- Description: Simple code for tracking the intro scene, playing audio and moving forward after a set amount of time
 */

public class Introchanger : MonoBehaviour
{
    [SerializeField] float targetTime = 0;

    private bool done = false;

    private AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        audio.Play("Van");
        audio.Stop("Level Theme");
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f && !done)
        {
            FindObjectOfType<GameManager>().LoadGame((SceneIndexes)6, (SceneIndexes)2);
            audio.Stop("Van");
            audio.Play("Level Theme");
            done = true;
        }
    }


}
