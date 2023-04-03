using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Listen = 0,
    LoadingPlanes,
    PlaceInstruments
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameState gameState;
    [SerializeField] GameObject listenUI, loadingUI, placementUI;
    [SerializeField] float loadingUIDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        SetGameState(GameState.LoadingPlanes);
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

    #region GAME STATES
    // Change actual game mode
    void SetGameState(GameState newState)
    {
        gameState = newState;

        switch (gameState)
        {
            case GameState.Listen:
                listenUI.SetActive(true);
                placementUI.SetActive(false);
                break;

            case GameState.LoadingPlanes:
                FindObjectOfType<ARRaycast>().GetComponent<ARRaycast>().enabled = false;
                StartCoroutine(HideOnTimer(loadingUI, loadingUIDelay));
                break;
                
            case GameState.PlaceInstruments:
                FindObjectOfType<ARRaycast>().GetComponent<ARRaycast>().enabled = true;
                listenUI.SetActive(false);
                placementUI.SetActive(true);
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
    #endregion

    IEnumerator HideOnTimer(GameObject go, float timer)
    {
        yield return new WaitForSeconds(timer);
        go.SetActive(false);
        SetGameState(GameState.PlaceInstruments);
    }
}
