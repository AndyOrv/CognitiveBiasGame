using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneIndexes
{
    MANAGER = 0,
    TITLE_SCREEN = 1,
    LEVEL_1 = 2
}


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;

    public virtual void firstLoad() { SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive); }
    private void Awake()
    {
        instance = this;

        firstLoad();

        Debug.Log((SceneIndexes)2);
    }
    

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadGame(SceneIndexes x, SceneIndexes y)
    {
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)(y), LoadSceneMode.Additive));
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)(x)));

        StartCoroutine(GetSceneLoadProgress());
    }

    public IEnumerator GetSceneLoadProgress()
    {
        for(int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
    }
}
