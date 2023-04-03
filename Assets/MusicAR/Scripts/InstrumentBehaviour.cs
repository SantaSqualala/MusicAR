using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstrumentBehaviour : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioClip solo, combined;

    // Start is called before the first frame update
    void Start()
    {
        PlayInstrument();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Pause music on this instrument
    public void PauseInstrument()
    {
        if (music != null)
        {
            music.Pause();

            if (GetComponent<RotateOnSelf>())
            {
                Destroy(music.transform.GetComponent<RotateOnSelf>());
            }
        }
    }

    // Stop the music on htis instrument
    public void StopInstrument()
    {
        if (music != null)
        {
            music.Stop();

            if (GetComponent<RotateOnSelf>())
            {
                Destroy(transform.GetComponent<RotateOnSelf>());
                music.transform.rotation = Quaternion.identity;
            }
        }
    }

    // Play this instrument
    public void PlayInstrument()
    {
        if (music != null)
        {
            music.Play();

            if(!GetComponent<RotateOnSelf>())
            {
                music.transform.AddComponent<RotateOnSelf>();
            }
        }
    }
}
