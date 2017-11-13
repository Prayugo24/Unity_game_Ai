using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

	public Slider slide;
	public Text coin;
	public Text time;

	//Memberi batasan waktu permainan 90 detik
	float countdown = 90;

	float timer = 0;
	// Use this for initialization
	void Start()
	{
		//Nilai Koin reset ke nilai 0 ketika pertama kali dijalankan
		Data.coin = 0;
		//90 detik diasumsi 1 menit 30 detik
		time.text = "01:30";
	}
	// Update is called once per frame
	void Update()
	{
		//Maksimal koin adalah 800
		if (Data.coin < 800)
		{
			//Setiap detik menambah 50 koin dan juga ditampilkan diprogress bar
			Data.coin += 50 * Time.deltaTime;
			slide.value = Data.coin;
			//Selain ditampilkan di progress bar, angka tersebut juga ditampilkan di text
			coin.text = Data.coin.ToString("000");
		}
		//Memproses untuk setiap 1 detik sekali
		timer += Time.deltaTime;
		if (timer > 1f)
		{
			timer = 0;
			//Jika batasan waktu masih ada sisa, maka setiap detik dikurangi satu
			if (countdown > 0)
			{
				countdown--;
				//Menampilkan dari sebuah angka menjadi waktu menit dan detik
				string minutes = Mathf.Floor(countdown / 60).ToString("00");
				string seconds = Mathf.Floor(countdown % 60).ToString("00");
				time.text = minutes + ":" + seconds;
			}
			//Jika waktu habis maka permainan selesai dan Player kalah
			else
			{
				Data.isGameOver = true;
				Data.isComplate = false;
			}
		}
	}
	}

