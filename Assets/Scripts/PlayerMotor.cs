using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Rigidbody RB;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    internal void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
        internal void camRotate(Vector3 _camRotation)
    {
        camRotation = _camRotation;
    }

    internal void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    private void FixedUpdate()
    {
        PerformMove();
        PerformRotate();

    }

    private void PerformMove()
    {
        if (velocity != Vector3.zero)
        {
            RB.MovePosition(RB.position+velocity * Time.fixedDeltaTime);
        }
    }
    private void PerformRotate()
    {
            RB.MoveRotation(RB.rotation*Quaternion.Euler(rotation));
            if (cam != null)
            {
                cam.transform.Rotate(-camRotation);
            }
    }
}
