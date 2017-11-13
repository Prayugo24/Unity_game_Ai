using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePlayEnd : MonoBehaviour {

	float timer = 0;
	// Update is called once per frame
	void Update()
	{
		/*Ketika permainan selesai, maka dalam waktu 2 detik menampilkan tampilan Gameover dari scene Gameover yang nanti akan dibuat*/
		if (Data.isGameOver)
		{
			timer += Time.deltaTime;
			if (timer > 2)
			{
				SceneManager.LoadScene("GameOber");
			}
		}
		//Keluar dari Aplikasi ketika tekan escape pada keyboard atau tekan back pada device mobile
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
