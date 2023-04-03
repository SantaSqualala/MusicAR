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
    [SerializeField] float timer = 5f;

    private RaycastHit rHit;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UI();

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

        if (Physics.Raycast(ray, out rHit, 5.0f) && (!rHit.transform.GetComponent<InstrumentBehaviour>() && !rHit.transform.GetComponent<RectTransform>()))
        {
            posHoverPoint.transform.position = rHit.point + (rHit.normal * 0.05f);
            posHoverPoint.transform.up = rHit.normal;
            StopAllCoroutines();
        }
    }

    public void HidePlacer()
    {
        posHoverPoint.SetActive(false);
    }

    private void UI()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out rHit, 5.0f) && rHit.transform.GetComponent<ShowUIElement>())
        {
            GetComponent<ShowUIElement>().Show();
        }
        else
        {
            GetComponent<ShowUIElement>().Show();
        }
    }

    private IEnumerator PlaceObjectValidationDelay()
    {
        yield return new WaitForSeconds(timer);
        posHoverPoint.SetActive(false);
    }
}
