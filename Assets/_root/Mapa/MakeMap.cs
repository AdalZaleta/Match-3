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

namespace Mangos
{
	public class MakeMap : MonoBehaviour {

		public VisualGrid Grid;
		[Range (1, 10)]
		public int filas;
		[Range (1, 10)]
		public int columnas;
		public Transform startPosition;
		public GameObject pivotes;
		public GameObject contenedorColumnas;
		public GameObject contenedorFilas;
		int[,] elemento;
		bool[,] espejo;
		int _actF;
		int _actC;
		int m_contador = 1;


		void Start ()
		{
			espejo = new bool[filas,columnas];
			elemento= new int[filas,columnas];
            int limit = 0;


            do {
                if (limit > 0) Debug.Log("Match at start, rebuilding map");
                limit++;
                for (int w = 0; w < filas; w++)
                {
                    for (int x = 0; x < columnas; x++)
                    {
                        espejo[w, x] = false;
                        elemento[w, x] = Random.Range(1, Grid.candies.Length-1);
                    }
                }
		        CheckMap();
            } while ( ViewMatchs());

			Grid.Setup(elemento);
		}

		public void ClearMap()
		{
            Debug.Log("Making candy values that matched 0");
			for(int i = 0; i < filas; i++)
			{
				for(int j = 0; j < columnas; j++)
				{
					if(espejo[i,j])
					{
						elemento[i,j] = 0;
						espejo[i,j] = false;
					}
				}
			}
		}

		void ViewElements()
		{
			for(int w = 0 ; w < filas; w++)
			{
				for(int x = 0 ; x < columnas; x++)
				{
					Debug.Log("Elemento["+w+"]["+x+"]: " + elemento[w,x]);
				}
			}
		}

		bool ViewMatchs()
		{
            Debug.Log("Checking if there's a match made");
			for(int w = 0 ; w < filas; w++)
			{
				for(int x = 0 ; x < columnas; x++)
				{
                    if (espejo[w, x])
                    {
                        Debug.Log("There were matches");
                        return true;
                    }

				}
			}
            Debug.Log("There were no matches");
			return false;
		}

		public void SelectPiece(int _fila, int _columna)
		{
			_actF = _fila;
			_actC = _columna;
		}

		public bool MakeMove(int _for, int _cor, int _fob, int _cob)
		{
            /*Debug.Log("Make Move()");
			int temp = 0;
			temp = elemento[_for,_cor];
			elemento[_for,_cor] = elemento[_fob,_cob];
			elemento[_fob,_cob] = temp;
			Grid.UpdateMatrix(elemento);
			CheckMap();
			if(ViewMatchs())
			{
				ClearMap();
				//MakeGravity();
				Grid.UpdateMatrix(elemento);
				return true;
			}
			elemento[_fob,_cob] = elemento[_for,_cor];
			elemento[_for,_cor] = temp;
			Grid.UpdateMatrix(elemento);
			return false;*/

            Debug.Log("Moving candies");
            int temp = 0;
            temp = elemento[_for, _cor];
            elemento[_for, _cor] = elemento[_fob, _cob];
            elemento[_fob, _cob] = temp;
            Grid.UpdateMatrix(elemento);
            CheckMap();
            if (ViewMatchs())
            {
                return true;
            }
            elemento[_fob, _cob] = elemento[_for, _cor];
            elemento[_for, _cor] = temp;
            Grid.UpdateMatrix(elemento);
            return false;
        }
		public int GetElement(int fila, int columna)
		{
			return elemento[fila,columna];
		}

		void CheckMap()
		{
            Debug.Log("Calculating matches");
			for(int i = 0 ; i < filas; i ++)
			{
				for(int j = 0; j < columnas - 1; j++)
				{
					if(CheckMatchRow(i,j,1))
					{
						espejo[i,j] = true;
					}
				}
			}

			for(int i = 0 ; i < filas - 1; i ++)
			{
				for(int j = 0; j < columnas; j++)
				{
					if(CheckMatchColumn(i,j,1))
					{
						espejo[i,j] = true;
					}
				}
			}
            //ViewElements();

        }

		public void MakeGravity()
		{
			Debug.Log("Making candies fall");

            Vector2Int[,] moveMap = new Vector2Int[filas, columnas];
            Vector2Int tempCor = new Vector2Int(0, 0);
            for (int i = 0; i < filas; i++)
                for (int k = 0; k < columnas; k++)
                    moveMap[i, k] = elemento[i,k] == -1 ? new Vector2Int(-1, -1) : new Vector2Int(i, k);

			bool listo = false, done = true;
			int temp = 0, j = columnas - 1, limitehardcode = 0;
			for(int i = 0; i < filas; i++)
			{
				limitehardcode = 0;
				listo = false;
				done = true;
				while(!listo && limitehardcode < 50)
				{
					if(elemento[i,j] != 0 && elemento[i,j-1] == 0)
					{
						done = false;
						temp = elemento[i,j];
						elemento[i,j] = elemento[i,j-1];
						elemento[i,j-1] = temp;

                        tempCor = moveMap[i, j];
                        moveMap[i, j] = moveMap[i, j - 1];
                        moveMap[i, j - 1] = tempCor;

                    }
					j--;
					if(j < 1)
					{
						j = columnas - 1;
						if(done)
						{
							listo = true;
						}
					}
					limitehardcode ++;
				}
			}

            Grid.CandyFall(moveMap);
        }

        public void FillEmptySpaces()
        {
            int[,] newCandyMap = new int[filas, columnas];
            for(int i = 0; i < filas; i++)
            {
                for(int j = 0; j < columnas; j++)
                {
                    if (elemento[i, j] == 0)
                    {
                        elemento[i, j] = Random.Range(1, Grid.candies.Length - 1);
                        newCandyMap[i, j] = elemento[i, j];
                    }
                    else
                    {
                        newCandyMap[i,j] = 0;
                    }
                }
            }
            UpdateVisualizer();
            Grid.SpawnNewCandies(newCandyMap);

        }

		public bool CheckMatchRow(int _for, int _cor, int _contador)
		{
			if(_cor < columnas - 1)
			{
				if(elemento[_for,_cor] == elemento[_for,_cor+1] && elemento[_for, _cor] != 0)
				{
					if(CheckMatchRow(_for, _cor + 1, _contador + 1))
					{
						espejo[_for,_cor] = true;
						return true;
					}
				}
				else
				{
					if(_contador > 2)
					{
						espejo[_for,_cor] = true;
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			if(_contador > 2)
			{
				espejo[_for,_cor] = true;
				return true;
			}
			return false;
		}
		public bool CheckMatchColumn(int _for, int _cor, int _contador)
		{
			if(_for < filas - 1)
			{
				if(elemento[_for,_cor] == elemento[_for + 1,_cor] && elemento[_for, _cor] != 0)
				{
					if(CheckMatchColumn(_for + 1, _cor, _contador + 1))
					{
						espejo[_for,_cor] = true;
						return true;
					}
				}
				else
				{
					if(_contador > 2)
					{
						espejo[_for,_cor] = true;
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			if(_contador > 2)
			{
				espejo[_for,_cor] = true;
				return true;
			}
			return false;
		}
		public bool CheckMatch(int _for, int _cor, int _contador)
		{
			if((_for < filas - 1) && (_cor < columnas - 1))
			{
				if(espejo[_for,_cor] == false)
				{
					if(elemento[_for,_cor] == elemento[_for,_cor+1])
					{
						if( CheckMatch(_for, _cor + 1, _contador + 1))
						{
							espejo[_for,_cor] = true;
						}
						else
						{
							espejo[_for,_cor] = false;
						}
					}
					if(elemento[_for,_cor] == elemento[_for+1,_cor])
					{
						if( CheckMatch(_for + 1, _cor, _contador + 1))
						{
							espejo[_for,_cor] = true;
						}
						else
						{
							espejo[_for,_cor] = false;
						}
					}
					else if(elemento[_for,_cor] != elemento[_for,_cor+1])
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
					else if(elemento[_for,_cor] == elemento[_for+1,_cor])
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

        public void UpdateVisualizer()
        {
            Grid.UpdateMatrix(elemento);
        }

        public void OnCandyDropFinish()
        {
            CheckMap();
            if (ViewMatchs())
            {
                ClearMap();
                UpdateVisualizer();
                Grid.OnCandiesDestroyed();
            }
            else
            {
                FillEmptySpaces();
            }
        }
    }
}
