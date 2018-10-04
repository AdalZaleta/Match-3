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
        public float candyFallAccel;

        private Vector2Int m_pickedCor;
        private Vector2Int m_dropedCor;
        private pickAndDrop picksAndDrops;

        private int[,] matrix;
        private GameObject[,] candyMatrix;
        private int candyDropFallback, candyDropFallbackCount;

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
            if (Input.GetKeyDown(KeyCode.R))
            {
                RedrawGrid();
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
            //RedrawGrid();
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

        void UpdateCandyMatrix()
        {
            Debug.Log("Updating internal game object candy matrix");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Vector2Int realPos = CompareToCellCenter(candyMatrix[i, j].transform.position);
                    if((realPos.x != i || realPos.y != j) && realPos.x != -1)
                    {
                        GameObject temp = candyMatrix[i, j];
                        candyMatrix[i, j] = candyMatrix[realPos.x, realPos.y];
                        candyMatrix[realPos.x, realPos.y] = temp;
                    }
                    else if(realPos.y == -1)
                    {
                        Debug.Log("A CANDY WAS NOT IN POSITION");
                    }
                }
            }
            //RedrawGrid();
        }

        public Vector2Int CompareToCellCenter(Vector3 pos)
        {
            Vector3Int temp = new Vector3Int();
            temp.z = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp.x = i;
                    temp.y = j;
                    if (grid.CellToWorld(temp) + grid.cellSize / 2 == pos)
                        return new Vector2Int(i, j);
                }
            }
            return new Vector2Int(-1, -1);
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
                        Debug.Log("Picked candy: " + picksAndDrops.pickedCor);
                        break;
                    }
                }
                if (broke)
                    break;
            }

        }

        public void OnCandyHold(Vector3 mousePos)
        {
            Vector3 candyPos = candyMatrix[picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y].transform.position;
            mousePos.z = grid.gameObject.transform.position.z - 2;
            candyMatrix[picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y].transform.position += (mousePos - candyPos) * Time.deltaTime * 15;
        }

        public void OnCandyHover()
        {
            //Por ahora no hace nada
        }

        public void OnCandyDropped()
        {
            Vector3Int droppedOn = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log("Candy Dropped On: " + droppedOn);
            if (droppedOn.x >= 0 && droppedOn.y >= 0 && droppedOn.x < width && droppedOn.y < height) //if en donde pregunto que rollo con los matches
            {
                if(makeMap.MakeMove(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y))
                {
                    StartCoroutine("CandySwapsHome", new Vector4(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y));
                }
                else
                {
                    StartCoroutine("CandyGoesHome", picksAndDrops.pickedCor);
                }
            }
            else
            {
                StartCoroutine("CandyGoesHome", picksAndDrops.pickedCor); 
            }
            
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

        void DestroyCandies()
        {
            Debug.Log("Destroying visual candies");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0 && candyMatrix[i, j].activeSelf)
                    {
                        PoolManager.Despawn(candyMatrix[i, j]);
                        Debug.Log("Destroyed i,j: " + i + ", " + j);
                    }
                }
            }
        }

        public void OnCandiesDestroyed()
        {
            UpdateCandyMatrix();
            makeMap.UpdateVisualizer();
            DestroyCandies();
            makeMap.MakeGravity();
        }

        public void CandyFall(Vector2Int[,] moveMap)
        {
            candyDropFallback = 0;
            candyDropFallbackCount = 0;
            bool atLeastOneDrop = false;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if ((moveMap[i, j].x != i || moveMap[i, j].y != j) && moveMap[i, j].x != -1)
                    {
                        atLeastOneDrop = true;
                        StartCoroutine("CandyDropsDown", new Vector4(moveMap[i, j].x, moveMap[i, j].y, i, j));
                        candyDropFallback++;
                    }
                }
            }
            if (!atLeastOneDrop)
            {
                UpdateCandyMatrix();
                makeMap.OnCandyDropFinish();
            }
            
        }

        public void SpawnNewCandies(int[,] news)
        {
            candyDropFallback = 0;
            candyDropFallbackCount = 0;
            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if(news[i,j] != 0)
                    {
                        candyMatrix[i,j] =  PoolManager.Spawn(candies[news[i, j]], grid.CellToWorld(new Vector3Int(i, j + height, 0)) + grid.cellSize/2, Quaternion.identity).gameObject;
                        StartCoroutine("CandyDropsDown", new Vector4(i, j, i, j));
                        candyDropFallback++;
                    }
                }
            }
        }

        IEnumerator CandyGoesHome(Vector2Int dropedCor)
        {
            Debug.Log("Candy returning to original position");
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

        IEnumerator CandySwapsHome(Vector4 pickedFrom)
        {
            Debug.Log("Two candies are swaping places");
            bool notHome1 = true, notHome2 = true;
            Vector3 destination1 = grid.CellToWorld(new Vector3Int((int)pickedFrom.z, (int)pickedFrom.w, 0)) + grid.cellSize / 2;
            Vector3 destination2 = grid.CellToWorld(new Vector3Int((int)pickedFrom.x, (int)pickedFrom.y, 0)) + grid.cellSize / 2;
            while (notHome1 || notHome2)
            {
                if (notHome1)
                {
                    Vector3 dir = (destination1) - candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y].transform.position;
                    candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y].transform.position += dir * Time.deltaTime * 10;
                    if (dir.magnitude <= 0.01f)
                    {
                        candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y].transform.position = destination1;
                        notHome1 = false;
                    }
                }
                if (notHome2)
                {
                    Vector3 dir = (destination2) - candyMatrix[(int)pickedFrom.z, (int)pickedFrom.w].transform.position;
                    candyMatrix[(int)pickedFrom.z, (int)pickedFrom.w].transform.position += dir * Time.deltaTime * 10;
                    if (dir.magnitude <= 0.01f)
                    {
                        candyMatrix[(int)pickedFrom.z, (int)pickedFrom.w].transform.position = destination2;
                        notHome2 = false;
                    }
                }
                yield return null;
            }
            UpdateCandyMatrix();
            makeMap.ClearMap();
            makeMap.UpdateVisualizer();
            OnCandiesDestroyed();
        }

        IEnumerator CandyDropsDown(Vector4 pickedFrom)
        {
            bool notHome1 = true;
            Vector3 destination1 = grid.CellToWorld(new Vector3Int((int)pickedFrom.z, (int)pickedFrom.w, 0)) + grid.cellSize / 2;
            float v = 0;
            while (notHome1)
            {
                Vector3 dir = (destination1) - candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y].transform.position;
                candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y].transform.position += dir.normalized * v * Time.deltaTime;
                if (candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y].transform.position.y <= destination1.y)
                {
                    candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y].transform.position = destination1;
                    notHome1 = false;
                }
                v += candyFallAccel;
                yield return null;
            }
            candyDropFallbackCount++;
            if (candyDropFallbackCount >= candyDropFallback)
            {
                Debug.Log("candyDrop callback");
                UpdateCandyMatrix();
                makeMap.OnCandyDropFinish();
            }
        }
    }
}

/*TODO:
    - Que haga los swaps si se necesita
    - Usar el arte que nos dieron
    - Hacer un script de los dulces para las animaciones y particulas
 */
