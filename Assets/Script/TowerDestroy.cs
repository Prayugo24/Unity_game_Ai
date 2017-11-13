using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDestroy : MonoBehaviour {
	/*public bool isPlayer = true; Menentukan kondisi ini sebagai tower Player atau Enemy

	private void OnDestroy(); Method dijalankan ketika tower terdestroy (Hancur)*/
	public bool isPlayer = true;
	private void OnDestroy()
	{
		//Dijalankan ketika kondisi game belum memiliki status selesai
		if (!Data.isGameOver)
			//Jika yang hancur itu Tower Player maka permainan tidak terselesaikan
		if (isPlayer)
		{
			Data.isGameOver = true;
			Data.isComplate = false;
			Debug.Log("Player Lost");
		}
		//Jika yang hancur itu Tower Player maka permainan terselesaikan
		else
		{
			Data.isGameOver = true;
			Data.isComplate = true;
			Debug.Log("Player Win");
		}
	}
}
