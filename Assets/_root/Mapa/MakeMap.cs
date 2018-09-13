using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elements
{
	FIRE,
	WATER,
	EARTH,
	AIR	
}

public class MakeMap : MonoBehaviour {

	[Range (1, 10)]
	public int filas;
	[Range (1, 10)]
	public int columnas;
	public Transform startPosition;
	public GameObject pivotes;
	public GameObject contenedorColumnas;
	public GameObject contenedorFilas;
	int[][] elemento;


	void Start () 
	{
		elemento = new int[filas][];

		for(int i = 0 ; i < columnas; i++)
		{
			GameObject.Instantiate(pivotes, new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z + i * 1.0f + 0.5f), Quaternion.identity);
		}

		for(int j = 0 ; j < filas; j++)
		{
			GameObject.Instantiate(pivotes, new Vector3(startPosition.position.x + j * 1.0f + 0.5f, startPosition.position.y, startPosition.position.z), Quaternion.identity);
		}

		for(int w = 0 ; w < filas; w++)
		{
			elemento[w] = new int[columnas];
			for(int x = 0 ; x < columnas; x++)
			{
				elemento[w][x] = Mathf.FloorToInt(Random.Range(0,3));
			}
		}

		for(int w = 0 ; w < filas; w++)
		{
			for(int x = 0 ; x < columnas; x++)
			{
				Debug.Log("Elemento: " + elemento[w][x]);
			}
		}
	} 
}
