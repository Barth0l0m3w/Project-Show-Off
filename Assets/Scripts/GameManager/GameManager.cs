using System;
using System.Collections;
using System.Collections.Generic;
using Udar.SceneManager;
using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public MovingCube platform;
    public XRKnob _xrKnob;
    public GameObject face;
    public MovingCube.ElevatorState stateToMoveInto;
    public SceneField sceneToLoad;
    
    public static GameManager Instance;

    private float value;
    private AsyncOperation _asyncOperation;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    private void OnEnable()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("OnSceneLoaded called in scene: " + scene.name);
        //Debug.Log("Knob value in scene: " + scene.name + " is: " + _xrKnob.value);
        //Debug.Log("Moving into state: " + stateToMoveInto + " in scene: " + scene.name);
        SetValue(_xrKnob.value);
        //Debug.Log("After setting the value, the current state is: " + platform.currentState + " in scene: " + scene.name);
    }

    // private void OnDisable()
    // {
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    

    public void SetValue(float pValue)
    {
        value = pValue;
        if (value < platform.leverMovingPoint)
        {
            platform.currentState = MovingCube.ElevatorState.STOP;
        }
        else
        {
            platform.currentState = stateToMoveInto;
        }
    }

    void Update()
    {
        if (platform.hasEnteredFreeFall)
        {
            stateToMoveInto = MovingCube.ElevatorState.FREEFALL;
        }
        else
        {
            stateToMoveInto = MovingCube.ElevatorState.CRUISE;
        }
    }

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

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSpecificScene()
    {
        SceneManager.LoadScene(0);
    }
}
