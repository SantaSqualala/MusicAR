using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnSelf : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Vector3 axis = Vector3.up;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
