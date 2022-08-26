using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    private bool swapStates = false;
    private GameObject player;

    private bool pausedGame = false;

    private void Start()
    {
        pauseMenu.SetActive(swapStates);
    }

    public void pauseState()
    {
        swapStates = !swapStates;
    }
    public void pauseGame()
    {
        pausedGame = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || pausedGame)
        {
            pauseState();
            pauseMenu.SetActive(swapStates);

            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().Paused = swapStates;

            pausedGame = false;
        }
    }

    public void exitGame()
    {
        FindObjectOfType<GameManager>().LoadGame(FindObjectOfType<GameManager>().currentScene, (SceneIndexes)1);
    }
    public void restart()
    {
        FindObjectOfType<GameManager>().ReloadScene();
    }
}
