using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class VisualGrid : MonoBehaviour
    {
        public int width;
        public int height;
        public GameObject[] candies; //Los prefabs de cada 'dulce' que va a haber
        public Grid grid;

        private Vector2Int m_pickedCor;
        private Vector2Int m_dropedCor;

        //Testing
        public int x, y, z;
        private int[][] matrix;
        private GameObject[][] candyMatrix;

        void Start()
        {
            matrix = new int[width][];
            candyMatrix = new GameObject[width][];
            for (int i = 0; i < width; i++)
            {
                matrix[i] = new int[height];
                candyMatrix[i] = new GameObject[height];
                //this is for thessthingg
                for (int j = 0; j < height; j++)
                {
                    matrix[i][j] = Random.Range(0, candies.Length);
                }
            }


            for(int i = 0; i < candies.Length; i++)
            {
                PoolManager.MakePool(candies[i], 50);
            }
        }

        void Update()
        {
            //Testing
            if (Input.GetKeyDown(KeyCode.U))
            {
                UpdateMatrix();
            }
        }

        public void UpdateMatrix(/* int[][] mat*/)
        {
            //TODO: save matrix

            //testing
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i][j] = Random.Range(0, candies.Length);
                }
            }
            RedrawGrid();
        }

        void RedrawGrid()
        {
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    if (candyMatrix[i][j] != null)
                        PoolManager.Despawn(candyMatrix[i][j]);

                    Transform candy = PoolManager.Spawn(candies[matrix[i][j]], grid.CellToWorld(new Vector3Int(i, j, 0)) + grid.cellSize/2 + Vector3.Scale(transform.position, Vector3.forward), Quaternion.identity);
                    candyMatrix[i][j] = candy.gameObject;
                }
            }
        }

        public void OnCandyPicked(GameObject picked)
        {
            bool broke = false;
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if(candyMatrix[i][j] == picked)
                    {
                        m_pickedCor = new Vector2Int(i, j);
                        broke = true;
                        Debug.Log("Se agarró el " + i + ", " + j);
                        break;
                    }
                }
                if (broke)
                    break;
            }

            //Llamat al script de adal para decirle cual agarre
        }

        public void OnCandyHold(Vector3 mousePos)
        {
            Vector3 candyPos = candyMatrix[m_pickedCor.x][m_pickedCor.y].transform.position;
            mousePos.z = grid.gameObject.transform.position.z - 2;
            candyMatrix[m_pickedCor.x][m_pickedCor.y].transform.position += (mousePos - candyPos) * Time.deltaTime * 15;
        }

        public void OnCandyHover()
        {
            //Por ahora no hace nada
        }

        public void OnCandyDropped()
        {
            m_dropedCor = m_pickedCor;
            if (true)
            {
                StartCoroutine("CandyGoesHome");
            }
        }

        public void OnGridStart(int[][] _grid)
        {

        }

        public void OnMatch(int[][] _grid)
        {

        }

        public void OnCandySpawn(int[][] _grid)
        {

        }


        IEnumerator CandyGoesHome()
        {
            bool notHome = true;
            Vector3 destination = grid.CellToWorld(new Vector3Int(m_dropedCor.x, m_dropedCor.y, 0)) + grid.cellSize/2;
            while (notHome)
            {
                Vector3 dir = (destination) - candyMatrix[m_dropedCor.x][m_dropedCor.y].transform.position;
                candyMatrix[m_dropedCor.x][m_dropedCor.y].transform.position += dir * Time.deltaTime * 10;
                if (dir.magnitude <= 0.01f)
                {
                    candyMatrix[m_dropedCor.x][m_dropedCor.y].transform.position = destination;
                    notHome = false;
                }
                yield return null;
            }
        }
    }
}

/*TODO:
    - Que haga los swaps si se necesita
    - Usar el arte que nos dieron
    - Hacer un script de los dulces para las animaciones y particulas
 */
