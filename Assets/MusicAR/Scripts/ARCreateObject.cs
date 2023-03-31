using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCreateObject : MonoBehaviour
{
    InstrumentManager instrumentManager;

    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] GameObject prefab;

    public void SelectInstrument()
    {

    }

    public void Create()
    {
        instrumentManager = FindObjectOfType<InstrumentManager>();

        if (prefab != null) 
        {
            instrumentManager.instance.AddInstrument(prefab, transform.position);
        }

        transform.gameObject.SetActive(false);
    }
}
