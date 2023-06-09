using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIElement : MonoBehaviour
{
    [SerializeField] GameObject uiToActivate;
    [SerializeField] bool active = false;

    public void ToggleUI()
    {
        active = !active;

        uiToActivate.SetActive(active);
    }

    public void Show()
    {
        active = true;
        uiToActivate.SetActive(active);
    }

    public void Hide()
    {
        active = false;
        uiToActivate.SetActive(active);
    }
}
