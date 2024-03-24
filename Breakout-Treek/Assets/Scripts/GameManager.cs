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
	private int bricksDestroyed;
	public float resetDelay = 1f;
	public TMP_Text livesText, bricksScoreTxt;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	private GameObject clonePaddle;

	public static GameManager instance;
	private Scene scene;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

	    Setup();
	}


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
			if(SceneManager.GetActiveScene().buildIndex + 1 < 3) //if the next scene in the build index is less than 3
            {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load the next scene
            }
            else
            {
				Time.timeScale = 0f; //stop the game (player won)
            }
			
		}
    }
    public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity); //Instantiates the paddle
		Instantiate(bricksPrefab, transform.position, Quaternion.identity); //Instantiates the bricks
		youWon.SetActive(false); //hides the you won and game over text
		gameOver.SetActive(false);
	}

	void CheckGameOver()
	{
		scene = SceneManager.GetActiveScene();

		if (bricks < 1) //if there is no bricks remaining
		{
			youWon.SetActive(true); //show you won text
			Invoke("NextLevel", resetDelay); //invoke the next level method


		}
		if (lives < 1) //if there is no lives left
		{
			gameOver.SetActive(true); //show the gameover text
			Time.timeScale = .25f; //slows down the game time
			Invoke("Reset", resetDelay); //invokes the reset method
		}
	}
	void Reset()
	{
		Time.timeScale = 1f; //sets time scale back to 1
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); //resets the scene
		bricks = 20; //resets the bricks interger
		lives = 3; //resets the lives
		bricksDestroyed = 0; //resets the score
		bricksScoreTxt.text = "Score: " + bricksDestroyed; //update score
		livesText.text = "Lives: " + lives; //updates lives
		youWon.SetActive(false);
		gameOver.SetActive(false);
	}
	public void LoseLife()
	{
		lives--; //takes away one life
		livesText.text = "Lives: " + lives;
		Destroy(clonePaddle); //destroys the paddle
		Invoke("SetupPaddle", resetDelay); //invokes the paddle creation
		CheckGameOver();
	}
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity); //Instantiates the paddle a paddle
	}
	public void DestroyBrick()
	{
		bricks--; //takes away the brick and adds one point to the score
		bricksDestroyed += 1;
		bricksScoreTxt.text = "Score: " + bricksDestroyed;
		CheckGameOver();
	}

	private void NextLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads the next level
		livesText.text = "Lives: " + lives;
		if (scene.name == "LevelOneTreek" || scene.name == "LevelTwoTreek")
		{
			lives += 1;  //if its the end of level 1 or two adds a bonus life and resets the brick counter
			bricks = 20;
		}

		youWon.SetActive(false);
	}
}

