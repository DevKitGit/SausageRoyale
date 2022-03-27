using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : MonoBehaviour
{
    public SphereCollider sphereCollider;
    [SerializeField] private float rotationSpeed;

    public bool gamePlaying;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (gamePlaying)
        {
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var parent = other.transform.parent;
        SausageController sausageController = null;
        if (parent != null && parent.TryGetComponent(out sausageController))
        {
            sausageController.inHotspot = true;
        }
    }
}
