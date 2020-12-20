using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LightingManager))]
public class CarController : MonoBehaviour
{ 
	public InputManager im;
	public LightingManager lm;
	public List<WheelCollider> throttlewheels;
	public List<GameObject> steeringwheels;
	public List<GameObject> meshes;
	public float strengthCoefficient = 1000000f;
	public float maxTurn = 50f;
	public Transform CM;
	public Rigidbody rb;
	public List<GameObject> tailLights;
	public AudioClip hornSound;
    private AudioSource hornAudio;

	void Start()
	{
		im = GetComponent<InputManager>();
		rb = GetComponent<Rigidbody>();
		hornAudio = GetComponent<AudioSource>();

		if(CM)
		{
			rb.centerOfMass = CM.localPosition;
		}
	}

	void Update()
	{
		if(im.l)
		{
			lm.ToggleHeadLights();
		}

		if(im.b)
		{
			foreach(GameObject tl in tailLights)
			{
				tl.GetComponent<Renderer>().material.SetColor("_EmissionColor", im.b ? new Color(0.5f,0.111f,0.111f) : Color.black);
			}
		}

		if(im.h)
		{
			hornAudio.PlayOneShot(hornSound, 1.0f);
		}
	}

	void FixedUpdate()
	{
		foreach (WheelCollider wheel in throttlewheels)
		{
			wheel.motorTorque = strengthCoefficient * Time.deltaTime * im.throttle;
		}

		foreach (GameObject wheel in steeringwheels)
		{
			wheel.GetComponent<WheelCollider>().steerAngle = maxTurn * im.steer;
			wheel.transform.localEulerAngles = new Vector3(0f, im.steer * maxTurn, 0f);
		}

		foreach (GameObject mesh in meshes)
		{
			mesh.transform.Rotate(rb.velocity.magnitude * (transform.InverseTransformDirection(rb.velocity).z >= 0 ? 1 : -1) / (2 * Mathf.PI * 0.33f), 0f, 0f);
		}

	}
}