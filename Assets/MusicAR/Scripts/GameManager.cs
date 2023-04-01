using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetGameState(GameState newState)
    {
        gameState = newState;

        switch (gameState)
        {
            case GameState.Listen: 
                listenUI.SetActive(true);

                break;

            case GameState.DisplayInfos:
                break;

            case GameState.LoadingPlanes:
                break;
                
            case GameState.PlaceInstruments:
                break;
            
            default: 
                break;
        }
    }
}
