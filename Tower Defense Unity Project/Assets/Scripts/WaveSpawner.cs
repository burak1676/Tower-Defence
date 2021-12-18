using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves; // dalgalar aras�ndaki s�re
	private float countdown = 5f; // ilk ba�taki s�re

	public Text waveCountdownText;

	public GameManager gameManager;
	public PlayerStats lives;
	private int waveIndex = 0;

	void Update ()
	{
        
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}
        
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate); // rate spawn lanan 2 d��man aras�ndaki mesafe veya base den ��k�� aral���
		}

		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}

}
