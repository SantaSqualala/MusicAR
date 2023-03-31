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
    [SerializeField] GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        if (!InstrumentManager.instance.enabled)
        {
            Debug.Log("No instrument manager !");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
