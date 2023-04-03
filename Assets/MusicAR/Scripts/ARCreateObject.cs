using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCreateObject : MonoBehaviour
{
    [SerializeField] ARRaycast raycastControler;
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

    public void SelectTanggu()
    {
        prefab = tanggu;
    }

    public void Create()
    {
        if (prefab != null) 
        {
            InstrumentManager.instance.AddInstrument(prefab, transform.position);
        }
        else
        {
            prefab = dizi;
            InstrumentManager.instance.AddInstrument(prefab, transform.position);
        }

        gameObject.SetActive(false);
    }
}
