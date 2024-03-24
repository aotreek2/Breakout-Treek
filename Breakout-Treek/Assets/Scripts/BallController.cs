//////////////////////////////////////////////
//Assignment/Lab/Project: Breakout_Treek
//Name: Ahmed Treek
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 3/21/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	public float initialVelocity = 600f;
	private Rigidbody rb;
	private bool ballInPlay;
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1") && ballInPlay == false) //if the mouse is clicked and the ball is not moving
		{
			transform.parent = null; //unparent the ball from paddle
			ballInPlay = true;
			rb.isKinematic = false; //makes the balls rigidbody kinematic and adds force
			rb.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
		}
	}
}

