using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        rb.velocity = Vector3.forward * playerSpeed * Time.deltaTime;

        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);


    }

}

