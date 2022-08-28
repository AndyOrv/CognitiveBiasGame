using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2narr : MonoBehaviour
{
    [SerializeField] char level;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("level" + level + 1);
    }

}
