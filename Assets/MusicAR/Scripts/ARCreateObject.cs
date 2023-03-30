using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCreateObject : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int maxInstances = 10;

    int instances = 0;

    public void Create()
    {
        if (prefab != null && instances < maxInstances) 
        {
            GameObject go = Instantiate(prefab, transform.position, prefab.transform.rotation);
            instances++;
        }

        transform.gameObject.SetActive(false);
    }
}
