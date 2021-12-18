using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
			
		}
		/*if (GameObject.FindGameObjectWithTag("deneme"))
        {
			Time.timeScale = 0.1f;
		}
		if (GameObject.FindGameObjectWithTag("deneme")==false)
		{
			Time.timeScale = 1f;
		}*/
	}

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
		Time.timeScale = 0.1f;

	}

	public void WinLevel ()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
		
	}

}
