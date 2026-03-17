using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Gravitational : MonoBehaviour
{
    public static List<Gravitational> otherGameObject;
    private Rigidbody rb;
    const float G = 0.006674f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherGameObject == null)
        {
            otherGameObject = new List<Gravitational>();
        }
        otherGameObject.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravitational obj in otherGameObject)
        {
            if (obj != this) { AttractionForce(obj); }
        }
    }

    void AttractionForce(Gravitational other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 dir = rb.position - otherRb.position;
        float dist = dir.magnitude;
        if (dist == 0)
        {
            return;
        }

        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(dist, 2));
        Vector3 gravitationalForce = forceMagnitude * dir.normalized;
        otherRb.AddForce(gravitationalForce);


    }
}
