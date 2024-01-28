using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
	public Transform camTransform;

    void Start()
    {
        camTransform = GameObject.Find("Cam").transform;
    }

    void Update()
    {
        transform.LookAt(camTransform);

    }
}
