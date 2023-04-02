using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Listen = 0,
    DisplayInfos,
    LoadingPlanes,
    PlaceInstruments
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameState gameState;
    [SerializeField] GameObject listenUI;
    [SerializeField] GameObject displayUI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (!InstrumentManager.instance.enabled)
        {
            Debug.Log("No instrument manager !");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set gamemode to placement mode
    public void PlacementMode()
    {
        SetGameState(GameState.PlaceInstruments);
    }

    // Set gamemode to listen mode
    public void ListenMode()
    {
        SetGameState(GameState.Listen);
    }

    // Change actual game mode
    public void SetGameState(GameState newState)
    {
        gameState = newState;

        switch (gameState)
        {
            case GameState.Listen: 
                FindObjectOfType<ARRaycast>().GetComponent<ARRaycast>().enabled = false;
                break;

            case GameState.DisplayInfos:
                FindObjectOfType<ARRaycast>().GetComponent<ARRaycast>().enabled = false;
                break;

            case GameState.LoadingPlanes:
                FindObjectOfType<ARRaycast>().GetComponent<ARRaycast>().enabled = false;
                break;
                
            case GameState.PlaceInstruments:
                FindObjectOfType<ARRaycast>().GetComponent<ARRaycast>().enabled = true;
                break;
            
            default: 
                break;
        }
    }

    // start the AR scene
    public void Play()
    {
        SceneManager.LoadScene("ARPlayMode");
    }

    // Exit the app immediately
    public void QuitApp()
    {
        Application.Quit();
    }
}
