using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInfo : MonoBehaviour
{
    Camera cam;
    [SerializeField] Transform target;
    [SerializeField] float delay = 2f;

    float t;

    // Update is called once per frame
    void Update()
    {
        RaycastHit rHit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rHit, 5.0f) && rHit.transform.GetComponentInParent<InstrumentBehaviour>())
        {
            target = rHit.transform;
            t -= Time.deltaTime;
        }
        else
        {
            target = null;
            t = delay;
        }

        // activate instrument on long look
        if(target != null && t <= 0f)
        {
            target.GetComponent<InstrumentBehaviour>().PlayInstrument();
        }
    }
}
