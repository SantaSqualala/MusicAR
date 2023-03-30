using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Camera))]
public class ARRaycast : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject posHoverPoint;
    [SerializeField] float timer = 2f;

    private RaycastHit rHit;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        // set hoverposition active
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            posHoverPoint.SetActive(true);
            TestScreenPosition();
        }

        // change position of the hovering asset
        if (Input.touches[0].phase == TouchPhase.Moved)
        {
            TestScreenPosition();
        }

        // deactivates hovering asset
        if (Input.touches[0].phase == TouchPhase.Ended)
        {
            StartCoroutine(PlaceObjectValidationDelay());
        }
    }

    // Place an hovering asset above the ground at targeted position
    private void TestScreenPosition()
    {
        Vector2 touchPos = Input.touches[0].position;
        Ray ray = cam.ScreenPointToRay(touchPos);

        if (Physics.Raycast(ray, out rHit, 5.0f))
        {
            posHoverPoint.transform.position = rHit.point + (rHit.normal * 0.05f);
            posHoverPoint.transform.up = rHit.normal;
            StopAllCoroutines();
        }
    }

    private IEnumerator PlaceObjectValidationDelay()
    {
        yield return new WaitForSeconds(timer);
        posHoverPoint.SetActive(false);
    }
}
