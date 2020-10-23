﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{ 

    // void OnCollisionEnter(Collision col)
    // {
    //     if(col.collider.name == "Obstacle")
    //     {
    //         print("Car Hit!");
    //     }
    // }

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;
    
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        print(verticalInput);
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce * 100f * Time.deltaTime;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce * 100f * Time.deltaTime;
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce * 100f * Time.deltaTime;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce * 100f * Time.deltaTime;
        currentbreakForce = isBreaking ? breakForce : 0f;
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
        // if (isBreaking)
        // {
        //     ApplyBreaking();
        // }
        // else
        // {
        //     // frontRightWheelCollider.brakeTorque = currentbreakForce;
        //     // frontLeftWheelCollider.brakeTorque = currentbreakForce;
        //     // rearLeftWheelCollider.brakeTorque = currentbreakForce;
        //     // rearRightWheelCollider.brakeTorque = currentbreakForce;
        // }
    }

    // private void ApplyBreaking()
    // {
    //     frontRightWheelCollider.brakeTorque = currentbreakForce;
    //     frontLeftWheelCollider.brakeTorque = currentbreakForce;
    //     rearLeftWheelCollider.brakeTorque = currentbreakForce;
    //     rearRightWheelCollider.brakeTorque = currentbreakForce;
    // }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;       
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}