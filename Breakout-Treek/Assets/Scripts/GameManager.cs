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
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public TMP_Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	private GameObject clonePaddle;
	void Awake()
	{
		Setup();
	}
	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
		youWon.SetActive(false);
		gameOver.SetActive(false);
	}

	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}
		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}
	}
	void Reset()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Destroy(clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity);
	}
	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
}

