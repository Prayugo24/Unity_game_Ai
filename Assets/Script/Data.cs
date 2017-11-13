using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
	public static float coin = 300;
	public static bool isGameOver = false;
	public static bool isComplate = false;
	/*1. Di class static ini tidak memerlukan MonoBehavior karena class ini dapat 
	 * langsung dipanggil tanpa harus menjadi Component di GameObject.
	2. Variable coin digunakan untuk menyimpan nilai Koin yang nantinya 
	   digunakan untuk membeli Player atau Stone untuk melawan musuh dengan nilai awal 300.
	3. Variable isGameOver digunakan untuk memberi kondisi jika permainan selesai.
	4. Variable isComplate digunakan untuk memberi status permainan menang atau kalah.*/
}