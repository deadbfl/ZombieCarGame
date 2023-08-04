using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private void FixedUpdate()
    {
        transform.position = target.position;    
        transform.rotation = target.rotation;
    }
}
