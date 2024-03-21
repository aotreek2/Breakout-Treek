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

public class PaddleController : MonoBehaviour
{
	public float paddleSpeed = 1f;
	private Vector3 playerPos = new Vector3(0, -9.5f, 0);
	void Update()
	{
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
		playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
		transform.position = playerPos;
	}
}


