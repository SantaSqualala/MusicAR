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
    [SerializeField] GameObject listenUI, displayUI, loadingUI;
    [SerializeField] float loadingUIDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetGameState(GameState.LoadingPlanes);
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
                StartCoroutine(HideOnTimer(loadingUI, loadingUIDelay));
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

    IEnumerator HideOnTimer(GameObject go, float timer)
    {
        yield return new WaitForSeconds(timer);
        go.SetActive(false);
        SetGameState(GameState.PlaceInstruments);
    }
}
