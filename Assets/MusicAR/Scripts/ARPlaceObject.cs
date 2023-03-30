using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(Camera))]
public class ARPlaceObject : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] private GameObject prefabToPlace;


    // Start is called before the first frame update
    void Start()
    {
        camera= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (Input.touches[0].phase == TouchPhase.Began)
        {
            Vector2 touchPos = Input.touches[0].position;
            Ray ray = camera.ScreenPointToRay(touchPos);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                Place(hit.point, hit.normal);
            }
        }
    }

    // Place instanciated prefab at point
    public void Place(Vector3 pos, Vector3 normal)
    {
        GameObject go = Instantiate(prefabToPlace);
        go.name = prefabToPlace.name;
        go.transform.position = pos;
        go.AddComponent<ARAnchor>();
    }
}