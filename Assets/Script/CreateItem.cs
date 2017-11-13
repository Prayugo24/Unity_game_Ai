using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour {
	
	public GameObject item;
	public int cost = 100;
	private Vector3 screenPoint;
	private Vector3 offset;

	//Method tersebut dipanggil ketika area gameobject ini yang terdapat collider diklik dengan mouse
	private void OnMouseDown()
	{
		//Dijalankan ketika sisa koin mencukupi untuk membuat membuat item/Object
		if (Data.coin >= cost)
		{
			//Item dibuat berdasarkan posisi dari gameobject ini
			Debug.Log("Create Item");
			GameObject _item = (GameObject)Instantiate(item, transform.position, Quaternion.identity);
			//Menonaktifkan semua behavior yang terdapat pada item
			foreach (Behaviour childCompnent in _item.GetComponentsInChildren<Behaviour>())
				childCompnent.enabled = false;
			//Mencatat posisi awal item dan posisi mouse
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
				Input.mousePosition.y, screenPoint.z));
			//Mengirimkan nilai posisi awal item, posisi awal mouse dan cost di Script DragDrop.cs pada item.
			DragDrop dd = _item.GetComponent<DragDrop>();
			dd.enabled = true;
			dd.screenPoint = screenPoint;
			dd.offset = offset;
			dd.cost = cost;
		}
		//Jika koin tidak mencukupi maka akan diinformasikan di Console.
		else
		{
			Debug.Log("Koin Tidak cukup");
		}
	}
}
