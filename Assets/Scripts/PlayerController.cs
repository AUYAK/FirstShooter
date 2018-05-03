using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed=5f;
    [SerializeField]
    private float lookSpeed = 3f;
    private PlayerMotor motor;
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }
    private void Update()
    {
        // Pozition
        var xPos = Input.GetAxisRaw("Horizontal");
        var zPos = Input.GetAxisRaw("Vertical");
        Vector3 movHor = Vector3.right * xPos;
        Vector3 movVer = Vector3.forward * zPos;
        Vector3 velocity = (movHor + movVer).normalized * speed;
        motor.Move(velocity);

        //Rotation
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f,yRot,0f) * lookSpeed;
        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f)*lookSpeed;
        motor.camRotate(cameraRotation);

    }
}
