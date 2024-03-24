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

public class Bricks : MonoBehaviour
{
	public GameObject brickParticle;
	void Start()
	{

	}
	void OnCollisionEnter(Collision other)
	{
		Instantiate(brickParticle, transform.position, Quaternion.identity); //Instantiates the particle effect when the brick is destroyed
		GameManager.instance.DestroyBrick(); //calls the method from the gamemanager instance
		Destroy(gameObject); 
	}
}


