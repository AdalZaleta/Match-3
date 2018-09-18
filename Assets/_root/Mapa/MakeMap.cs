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
	bool[][] espejo;
	int _actF;
	int _actC;
	int m_contador = 1;


	void Start () 
	{
		elemento = new int[filas][];
		espejo = new bool[filas][];

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
			espejo[w] = new bool[columnas];
			for(int x = 0 ; x < columnas; x++)
			{
				espejo[w][x] = false;
				elemento[w][x] = Mathf.FloorToInt(Random.Range(1,4));
			}
		}

		ViewElements();
		ViewMatchs();
	}

	void ViewElements()
	{
		for(int w = 0 ; w < filas; w++)
		{
			for(int x = 0 ; x < columnas; x++)
			{
				Debug.Log("Elemento["+w+"]["+x+"]: " + elemento[w][x]);
			}
		}
	}

	void ViewMatchs()
	{
		for(int w = 0 ; w < filas; w++)
		{
			for(int x = 0 ; x < columnas; x++)
			{
				Debug.Log("Valor de ["+w+"]["+x+"]: " + espejo[w][x]);
			}
		}
	}

	public void SelectPiece(int _fila, int _columna)
	{
		_actF = _fila;
		_actC = _columna;
	}

	public void MakeMove(int _for, int _cor, int _fob, int _cob)
	{
		int temp = 0;
		temp = elemento[_for][_cor];
		elemento[_for][_cor] = elemento[_fob][_cob];
		elemento[_fob][_cob] = temp;

	}
	public int GetElement(int fila, int columna)
	{
		return elemento[fila][columna];
	}
	public bool CheckMatch(int _for, int _cor, int _contador)
	{
		if((_for < filas - 1) && (_cor < columnas - 1))
		{
			if(espejo[_for][_cor] == false)
			{
				if(elemento[_for][_cor] == elemento[_for][_cor+1])
				{
					if( CheckMatch(_for, _cor + 1, _contador + 1))
					{
						espejo[_for][_cor] = true;
					}
					else
					{
						espejo[_for][_cor] = false;
					}
				}
				if(elemento[_for][_cor] == elemento[_for+1][_cor])
				{
					if( CheckMatch(_for + 1, _cor, _contador + 1))
					{
						espejo[_for][_cor] = true;
					}
					else
					{
						espejo[_for][_cor] = false;
					}
				}
				else if(elemento[_for][_cor] != elemento[_for][_cor+1])
				{
					if(_contador > 2)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else if(elemento[_for][_cor] == elemento[_for+1][_cor])
				{
					if(_contador > 2)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
		}
		return false;
	}
}
