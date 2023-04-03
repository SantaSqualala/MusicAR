using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    [SerializeField] GameObject ui;

    public void Display()
    {
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
