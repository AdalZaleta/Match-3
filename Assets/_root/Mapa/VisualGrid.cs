using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    struct pickAndDrop
    {
        public Vector2Int pickedCor;
        public Vector2Int droppedCor;
        public Vector3 destination;
        public bool goingHome;
    }

    public class VisualGrid : MonoBehaviour
    {
        public int width;
        public int height;
        public GameObject[] candies; //Los prefabs de cada 'dulce' que va a haber
        public Grid grid;
        public MakeMap makeMap;

        private Vector2Int m_pickedCor;
        private Vector2Int m_dropedCor;
        private pickAndDrop picksAndDrops;

        //Testing
        public int x, y, z;
        private int[,] matrix;
        private GameObject[,] candyMatrix;

        void Start()
        {
            picksAndDrops = new pickAndDrop();
        }

        public void Setup(int[,] mat)
        {
            matrix = mat;
            width = matrix.GetLength(0);
            height = matrix.GetLength(1);
            candyMatrix = new GameObject[width, height];

            for (int i = 0; i < candies.Length; i++)
            {
                PoolManager.MakePool(candies[i], 50);
            }
            RedrawGrid();
        }

        void Update()
        {
            //Testing
            if (Input.GetKeyDown(KeyCode.U))
            {
                UpdateMatrixTesting();
            }
           
        }

        public void UpdateMatrixTesting(/* int[,] mat*/)
        {
            //TODO: save matrix

            //testing
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    matrix[i,j] = Random.Range(0, candies.Length);
                }
            }
            RedrawGrid();
        }

        public void UpdateMatrix(int[,] mat)
        {
            matrix = mat;
            RedrawGrid();
        }

        void RedrawGrid()
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (candyMatrix[i,j] != null)
                        PoolManager.Despawn(candyMatrix[i,j]);

                    Transform candy = PoolManager.Spawn(candies[matrix[i,j]], grid.CellToWorld(new Vector3Int(i, j, 0)) + grid.cellSize/2 + Vector3.Scale(transform.position, Vector3.forward), Quaternion.identity);
                    candyMatrix[i,j] = candy.gameObject;
                }
            }
        }

        public void OnCandyPicked(GameObject picked)
        {
            
            bool broke = false;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (candyMatrix[i, j] == picked)
                    {
                        picksAndDrops.pickedCor = new Vector2Int(i, j);
                        picksAndDrops.destination = grid.CellToWorld(new Vector3Int(i, j, 0)) + grid.cellSize / 2;
                        picksAndDrops.goingHome = false;
                        broke = true;
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
            //Vector3 candyPos = candyMatrix[m_pickedCor.x, m_pickedCor.y].transform.position;
            Vector3 candyPos = candyMatrix[picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y].transform.position;
            mousePos.z = grid.gameObject.transform.position.z - 2;
            //candyMatrix[m_pickedCor.x, m_pickedCor.y].transform.position += (mousePos - candyPos) * Time.deltaTime * 15;
            candyMatrix[picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y].transform.position += (mousePos - candyPos) * Time.deltaTime * 15;
        }

        public void OnCandyHover()
        {
            //Por ahora no hace nada
        }

        public void OnCandyDropped()
        {
            Vector3Int droppedOn = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (droppedOn.x >= 0 && droppedOn.y >= 0 && droppedOn.x < width && droppedOn.y < height) //if en donde pregunto que rollo con los matches
            {
                makeMap.MakeMove(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y);
            }
            else
            {
                StartCoroutine("CandyGoesHome", picksAndDrops.pickedCor); 
            }
            Debug.Log(grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }

        public void OnGridStart(int[,] _grid)
        {

        }

        public void OnMatch(int[,] _grid)
        {

        }

        public void OnCandySpawn(int[,] _grid)
        {

        }


        IEnumerator CandyGoesHome(Vector2Int dropedCor)
        {
            bool notHome = true;
            Vector3 destination = grid.CellToWorld(new Vector3Int(dropedCor.x, dropedCor.y, 0)) + grid.cellSize / 2;
            while (notHome)
            {
                Vector3 dir = (destination) - candyMatrix[dropedCor.x, dropedCor.y].transform.position;
                candyMatrix[dropedCor.x, dropedCor.y].transform.position += dir * Time.deltaTime * 10;
                if (dir.magnitude <= 0.01f)
                {
                    candyMatrix[dropedCor.x, dropedCor.y].transform.position = destination;
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
