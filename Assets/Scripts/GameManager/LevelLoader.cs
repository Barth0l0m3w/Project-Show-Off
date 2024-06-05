using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Udar.SceneManager;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public SceneField sceneToLoad; 
    
    public static LevelLoader Instance;
    
    private AsyncOperation _asyncOperation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        Debug.Log(_asyncOperation);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded called in scene: " + scene.name);
        //Debug.Log("Knob value in scene: " + scene.name + " is: " + _xrKnob.value);
        //Debug.Log("Moving into state: " + stateToMoveInto + " in scene: " + scene.name);
        GameManager.Instance.SetValue(GameManager.Instance._xrKnob.value);
        //Debug.Log("After setting the value, the current state is: " + platform.currentState + " in scene: " + scene.name);
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    //Source: https://gamedev.stackexchange.com/questions/185528/preload-scene-in-unity
    private IEnumerator LoadSceneASyncProcess()
    {
        this._asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad.Name);

        this._asyncOperation.allowSceneActivation = false;

        while (!this._asyncOperation.isDone)
        {
            Debug.Log($"[scene]: {sceneToLoad.Name} [load progress]: {this._asyncOperation.progress}");

            yield return null;
        }
    }
    
    public void PreloadScene()
    {
        this.StartCoroutine(LoadSceneASyncProcess());
    }
    
    public void LoadPreloadedScene()
    {
        this._asyncOperation.allowSceneActivation = true;
    }
}
