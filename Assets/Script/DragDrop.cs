using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour {

	[HideInInspector]
	//Digunakan untuk menyimpan nilai posisi mouse
	public Vector3 screenPoint;
	[HideInInspector]
	//Digunakan untuk menyimpan selisih dari posisi object dengan posisi mouse
	public Vector3 offset;
	[HideInInspector]
	//Digunakan untuk menyimpan berapa koin yang harus dikeluarkan untuk membuat player atau stone
	public int cost;
	[HideInInspector]
	//Kondisi awal ketika Gameobject terbuat, secara otomatis mengikuti mouse 
	//untuk meletakkan gameobject tersebut
	public bool follow = true;
	private void Update()
	{
		//Ketika mengikuti object mengikuti mouse
		if (follow)
		{
			//Posisi mouser saat ini
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			//Menentukan posisi gameobject yang didapat dari posisi mouse awal dan posisi mouse sekarang.
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
			/*Ketika melepaskan mouse saat berada di area sebelah kanan 
			 * screen/layar maka membuat gameobject tidak mengikuti mouse, 
			 * mengurangi koin yang dimiliki dengan harga item tersebut dan 
			 * juga mengaktifkan semua behavior yang dimiliki object tersebut.*/
			if (Input.GetMouseButtonUp(0))
			{
				if (transform.position.x < 0 && transform.position.y > -2f)
				{
					follow = false;
					Data.coin -= cost;
					foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
						childCompnent.enabled = true;
				}
				/*Jika gameobject diletakkan di area yang tidak 
				 * diijinkan maka koin tidak dikurangi dan gameobject 
				 * tersebut akan dihilangkan*/
				else
				{
					Destroy(gameObject);
					Debug.Log("Meletakkan area yg tidak diijinkan");
				}
			}
		}
	}
}
