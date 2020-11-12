using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CarController : MonoBehaviour
{ 
	public InputManager im;
	public List<WheelCollider> throttlewheels;
	public List<WheelCollider> steeringwheels;
	public float strengthCoefficient = 1000000f;
	public float maxTurn = 50f;

	void Start()
	{
		im = GetComponent<InputManager>();
	}

	void FixedUpdate()
	{
		foreach (WheelCollider wheel in throttlewheels)
		{
			wheel.motorTorque = strengthCoefficient * Time.deltaTime * im.throttle;
		}

		foreach (WheelCollider wheel in steeringwheels)
		{
			wheel.steerAngle = maxTurn * im.steer;
		}

	}
}