using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;

    private Rigidbody rb = null;
    private Vector3 input = Vector3.zero;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = movementSpeed * input;
    }
}