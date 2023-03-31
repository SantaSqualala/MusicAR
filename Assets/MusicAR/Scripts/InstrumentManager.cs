using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentManager : MonoBehaviour
{
    [HideInInspector] public static InstrumentManager instance;

    [Header("Instruments")]
    [SerializeField] List<InstrumentBehaviour> instruments = new List<InstrumentBehaviour>();
    [Header("Music")]
    [SerializeField] float fadeDelay = 1.0f;
    [SerializeField] bool muteAll = false;
    [Header("Instrument deletion")]
    [SerializeField] int maxInstrumentsAllowed = 10;
    [SerializeField] GameObject instrumentDeletionMessage;
    int instrumentsInPlace = 0;    

    // Start is called before the first frame update
    void Start()
    { 
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add an instrument at position
    public void AddInstrument(GameObject prefab, Vector3 position)
    {
        GameObject go = Instantiate(prefab);
        instruments.Add(go.GetComponent<InstrumentBehaviour>());
        go.transform.position = position;
        instrumentsInPlace++;

        // remove 1rst instrument if 
        if(instrumentsInPlace >= maxInstrumentsAllowed)
        {
            RemoveInstrument(instruments[0].gameObject);
        }
    }

    // Remove a specific instrument
    public void RemoveInstrument(GameObject go)
    {
        instruments.Remove(go.GetComponent<InstrumentBehaviour>());
        Destroy(go);
    }

    // Remove all instruments
    public void RemoveAllInstruments()
    {
        foreach (InstrumentBehaviour instrument in instruments)
        {
            Destroy(instrument.gameObject);
        }
        instruments.Clear();
    }

    // Restart all instruments songs at once
    public void ResetAllInstruments()
    {
        StopAllInstruments();
        PlayAllInstruments();
    }

    // Stop all instruments at once
    public void StopAllInstruments()
    {
        foreach (var instrument in instruments)
        {
            instrument.StopInstrument();
        }
    }

    // Pause all instruments at once
    public void PauseAllInstruments()
    {
        foreach (var instrument in instruments)
        {
            instrument.PauseInstrument();
        }
    }

    // Play all instruments at once
    public void PlayAllInstruments()
    {
        foreach (var instrument in instruments)
        {
            instrument.PlayInstrument();
        }
    }

    // Toggle mute for all instruments (but let them play)
    public void ToggleMute()
    {
        muteAll = !muteAll;

        foreach (var instrument in instruments)
        {
            instrument.GetComponent<AudioSource>().mute = muteAll;
        }
    }
}
