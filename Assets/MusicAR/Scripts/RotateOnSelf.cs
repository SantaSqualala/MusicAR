using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnSelf : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 axis = Vector3.one;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
