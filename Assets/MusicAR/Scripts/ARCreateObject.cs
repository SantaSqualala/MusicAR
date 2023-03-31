using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCreateObject : MonoBehaviour
{
    [SerializeField] GameObject dizi, guzheng, tanggu;
    GameObject prefab;

    public void SelectDizi()
    {
        prefab = dizi;
    }

    public void SelectGuzheng()
    {
        prefab = guzheng;
    }

    public void Tanggu()
    {
        prefab = tanggu;
    }

    public void Create()
    {
        if (prefab != null) 
        {
            InstrumentManager.instance.AddInstrument(prefab, transform.position);
        }

        transform.gameObject.SetActive(false);
    }
}
