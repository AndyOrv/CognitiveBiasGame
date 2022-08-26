using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneIndexes
{
    MANAGER = 0,
    TITLE_SCREEN = 1,
    LEVEL_1 = 2,
    LEVEL_2 = 3,
    LEVEL_3 = 4,
    LEVEL_4 = 5,
}


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    public Slider progressbar;

    public SceneIndexes currentScene;

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

        currentScene = y;

        StartCoroutine(GetSceneLoadProgress());
    }

    public void ReloadScene()
    {
        LoadGame(currentScene, currentScene);
    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        for(int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;

                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = totalSceneProgress / scenesLoading.Count;

                Debug.Log(totalSceneProgress);
                progressbar.value = (totalSceneProgress);


                yield return null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
    }
}
