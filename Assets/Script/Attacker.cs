using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	public bool isPlayer = true;
	private bool isMove = true;
	public int attact = 100;
	public int defense = 200;
	[HideInInspector]
	public int underAttact;
	private float timer = 0;
	private float posYLawan;
	private bool isCari = false;
	private string nameTagLawan;

	/*public bool isPlayer = true; digunakan untuk menentukan apakah script ini digunakan sebagai enemy atau player

	private bool isMove = true; digunakan untuk memberi kondisi apakah sedang berjalan atau sedang menyerang

 	public int attact = 100; digunakan untuk memberi nilai untuk kemampuan menyerang

 	public int defense = 200; digunakan untuk memberi nilai bertahan ketika menerima serangan

 	[HideInInspector] digunakan untuk tidak menampilkan variable public setelah baris ini di Inspector

 	public int underAttact; digunakan untuk seberapa besar kekurangan serangan yang diterimanya

  	private float timer = 0; digunakan untuk menghitung waktu

  	private float posYLawan; digunakan untuk menyimpan posisi vertikal pada lawan (player/enemy)

  	private bool isCari = false; digunakan untuk meyimpan kondisi apakah lawan berada didalam area trigger atau tidak.

 	private string nameTagLawan; memberi nama Tag lawan (Player/Enemy)
	*/

	// Use this for initialization
	/*Memberikan nilai tag yang berlawanan dengan tag pada gameobject tersebut*/
	void Start()
	{
		if (isPlayer)
		{
			nameTagLawan = "Enemy";
		}
		else
		{
			nameTagLawan = "Player";
		}
	}
	// Update is called once per frame
	/*Method yang digunakan untuk memproses secara berulang yang code 
	 * yang berada didalamnya dengan kecepatan FPS (Frame per second) 
	 * sehingga dapat meningkatkan performa.*/
	void FixedUpdate()
	{
		//Kondisi ini dijalankan ketika script ini digunakan oleh GameObject Player
		if (isPlayer)
		{
			if (isMove)
			{
				//Menggerakkan Gameobject dengan arah ke kanan (Sumbu x) sejauh 0.5 setiap detiknya.
				transform.position += transform.right * Time.deltaTime * 0.5f;
				/*Jika lawan dalam area trigger dan posisinya tidak sejajar 
				 * maka Gameobject akan mendekati dengan mengubah posisi vertikal untuk menyamai posisi lawan.*/
				if (transform.position.y >= (posYLawan + 0.1f) && isCari)
				{
					transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
				}
				if (transform.position.y <= (posYLawan - 0.1f) && isCari)
				{
					transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
				}
			}
			/*Jika kondisi  tidak dalam bergerak dan bersentuhan dengan lawan, 
			 * maka setiap 0.6 detik nilai pertahanan dikurangi nilai attact 
			 * penyerang dengan memberi animasi perubahan tinggi Gameobject*/
			else
			{
				// attact
				timer += Time.deltaTime;
				if (timer > 0.6f)
				{
					defense -= underAttact;
					transform.localScale = new Vector3(1, 1f);
					timer = 0;
				}
				else if (timer > 0.5f)
				{
					transform.localScale = new Vector3(1, 1.2f);
				}
			}
		}
		else
		{
			if (isMove)
			{
				transform.position -= transform.right * Time.deltaTime * 0.5f;
				if (transform.position.y >= (posYLawan + 0.1f) && isCari)
				{
					transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
				}
				if (transform.position.y <= (posYLawan - 0.1f) && isCari)
				{
					transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
				}
			}
			else
			{
				// attact
				timer += Time.deltaTime;
				if (timer > 0.6f)
				{
					defense -= underAttact;
					transform.localScale = new Vector3(1, 1f);
					timer = 0;
				}
				else if (timer > 0.5f)
				{
					transform.localScale = new Vector3(1, 1.2f);
				}
			}
		}
		/*Jika tidak memiliki pertahanan maka Gameobject(Player/Enemy) 
		 * akan dihilangkan*/
		if (defense <= 0)
		{
			Destroy(gameObject);
		}
		//Jika posisi Gameobject diluar area, maka gameobject tersebut akan dihilangkan.
		if (transform.position.x > 9 || transform.position.x < -9)
		{
			Destroy(gameObject);
		}
	}
	/*Jika object bersentuhan dengan object lawan(Player/Enemy) 
	 * dan dalam kondisi masih jalan, maka beri kondisi gameobject 
	 * dalam kondisi diam dan mengirimkan nilai attact ke lawan 
	 * untuk mengurangi nilai pertahanan lawan.
	*/
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.transform.tag.Equals(nameTagLawan) && isMove)
		{
			isMove = false;
			Attacker m = collision.gameObject.GetComponent<Attacker>();
			if (m != null) m.underAttact = attact;
			Defender d = collision.gameObject.GetComponent<Defender>();
			if (d != null) d.underAttact = attact;
		}
	}
	/*Jika gameobject lawan berada didalam area trigger, 
	 * maka gameobject dalam status pencarian posisi lawan 
	 * dengan memanfaatkan posisi vertikal lawan untuk 
	 * menentukan perubahan posisi gameobject.*/
	public void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.transform.tag.Equals(nameTagLawan))
		{
			isCari = true;
			posYLawan = collision.transform.position.y;
		}
	}
	/*Jika gameobject tidak lagi bersentuhan dengan lawan maka 
	 * mengubah kondisi dikembalikan seperti semua dengan 
	 * melanjutkan pergerakkan ke arah lawan.*/
	public void OnCollisionExit2D(Collision2D collision)
	{
		isMove = true;
		transform.localScale = new Vector3(1, 1f);
	}
}
