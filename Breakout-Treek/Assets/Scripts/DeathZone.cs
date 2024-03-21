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

public class DeathZone : MonoBehaviour
{
	GameManager GM;
	void Start()
	{
		GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	void OnTriggerEnter(Collider col)
	{
		GM.LoseLife();
	}
}

