using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{


    public class VisualGrid1 : MonoBehaviour
    {
        public int width;
        public int height;
        public GameObject[] candies; //Los prefabs de cada 'dulce' que va a haber
        public Grid grid;
        public MakeMap makeMap;
        public float candyFallAccel;
        [SerializeField]
        private bool canPlay;

        private Vector2Int m_pickedCor;
        private Vector2Int m_dropedCor;
        private pickAndDrop picksAndDrops;
        
        private int[,] matrix; //Matrix with values for the game
        private GameObject[,] candyMatrix; //Matrix with gameobjects
        private int candyDropFallback, candyDropFallbackCount;

        private float fallVelocity = 0.7f;

        void Start()
        {
            picksAndDrops = new pickAndDrop();
            canPlay = true;
            PoolManager.ClearPools();
        }

        public void Setup(int[,] mat) //This is called by MakeMap
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
            /*if (Input.GetKeyDown(KeyCode.U))
            {
                UpdateMatrixTesting();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RedrawGrid();
            }*/
           
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

        public void UpdateMatrix(int[,] mat) //This is called by MakeMap
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
                    
                    if (candies[matrix[i,j]] != null)
                    {
                        Debug.Log("Trying to spawn: " + candies[matrix[i, j]].name);
                        Transform candy = PoolManager.Spawn(candies[matrix[i, j]], grid.CellToWorld(new Vector3Int(i, j, 0)) + grid.cellSize / 2 + Vector3.Scale(transform.position, Vector3.forward), Quaternion.identity);
                        candyMatrix[i, j] = candy.gameObject;
                    } 
                }
            }
        }

        void SwapCandyMatrix(int x1, int y1, int x2, int y2)
        {
            GameObject temp = candyMatrix[x1, y1];
            candyMatrix[x1, y1] = candyMatrix[x2, y2];
            candyMatrix[x2, y2] = temp;
        }

        void ClearCandyMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        candyMatrix[i, j] = null;
                    }
                }
            }
        }

        void UpdateCandyMatrix()
        {
            /*Debug.Log("Updating internal game object candy matrix");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        candyMatrix[i, j] = null;
                    }
                    else
                    {
                        Vector2Int realPos = CompareToCellCenter(candyMatrix[i, j].transform.position);
                        if ((realPos.x != i || realPos.y != j) && realPos.x != -1)
                        {
                            GameObject temp = candyMatrix[i, j];
                            candyMatrix[i, j] = candyMatrix[realPos.x, realPos.y];
                            candyMatrix[realPos.x, realPos.y] = temp;
                        }
                        else if (realPos.y == -1)
                        {
                            Debug.LogError("A CANDY WAS NOT IN POSITION");
                        }
                    }
                }
            }*/
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
            if (canPlay)
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

        }

        public bool OnCandyPicked(Vector3Int picked)
        {
            Debug.Log("picked: " + picked);
            if (canPlay)
            {
                picksAndDrops.pickedCor = new Vector2Int(picked.x, picked.y);
                picksAndDrops.destination = grid.CellToWorld(new Vector3Int(picked.x, picked.y, 0)) + grid.cellSize / 2;
                picksAndDrops.goingHome = false;
                return true;
            }
            return false;
        }

        public void OnCandyHold(Vector3 mousePos)
        {
            if (canPlay)
            {
                Vector3 candyPos = candyMatrix[picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y].transform.position;
                mousePos.z = grid.gameObject.transform.position.z - 2;
                candyMatrix[picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y].transform.position += (mousePos - candyPos) * Time.deltaTime * 15;
            }
        }

        public void OnCandyHover()
        {
            //Por ahora no hace nada
        }

        public void OnCandyDropped()
        {
            if (canPlay)
            {
                Vector3Int droppedOn = grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Debug.Log("Candy Dropped On: " + droppedOn);
                if (droppedOn.x >= 0 && droppedOn.y >= 0 && droppedOn.x < width && droppedOn.y < height) //if en donde pregunto que rollo con los matches
                {
                    if (makeMap.MakeMove(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y)) //Entro si esque se hace un match
                    {
                        //StartCoroutine("CandySwapsHome", new Vector4(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y));
                        CandySwapsHome2(new Vector4(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y));
                    }
                    else
                    {
                        //StartCoroutine("CandyGoesHome", picksAndDrops.pickedCor);
                        CandyGoesHome2(picksAndDrops.pickedCor);
                    }
                }
                else
                {
                    //StartCoroutine("CandyGoesHome", picksAndDrops.pickedCor);
                    CandyGoesHome2(picksAndDrops.pickedCor);
                }
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
            //UpdateCandyMatrix();
            ClearCandyMatrix();
            makeMap.UpdateVisualizer(); //This calls UpdateMatrix
            DestroyCandies();
            makeMap.MakeGravity(); //Llama CandyFall
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
                        //StartCoroutine("CandyDropsDown", new Vector4(moveMap[i, j].x, moveMap[i, j].y, i, j));
                        CandyDropsDown2(new Vector4(moveMap[i, j].x, moveMap[i, j].y, i, j));
                        candyDropFallback++;
                    }
                }
            }
            if (!atLeastOneDrop)
            {
                UpdateCandyMatrix();
                makeMap.OnCandyDropFinish();
            }
            else
            {
                Invoke("OnCandyFallFinish", fallVelocity);
            }
        }

        public void SpawnNewCandies(int[,] news)
        {
            candyDropFallback = 0;
            candyDropFallbackCount = 0;
            bool atLeastOneDrop = false;
            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if(news[i,j] != 0)
                    {
                        atLeastOneDrop = true;
                        candyMatrix[i,j] =  PoolManager.Spawn(candies[news[i, j]], grid.CellToWorld(new Vector3Int(i, j + height, 0)) + grid.cellSize/2, Quaternion.identity).gameObject;
                        //StartCoroutine("CandyDropsDown", new Vector4(i, j, i, j));
                        CandyDropsDown2(new Vector4(i, j, i, j));
                        candyDropFallback++;
                    }
                }
            }

            if(atLeastOneDrop)
                Invoke("OnCandyFallFinish", fallVelocity);
        }

        void OnCandyFallFinish()
        {
            Debug.Log("candyDrop callback");
            UpdateCandyMatrix();
            makeMap.OnCandyDropFinish(); //Llama OnCandiesDestroyed
            canPlay = true;
        }

        void CandyGoesHome2(Vector2Int dropedCor)
        {
            //Initializing 
            canPlay = false;
            Debug.Log("Candy returning to original position 2");
            //Declaring variables for easier use
            Vector3 destination = picksAndDrops.destination;
            GameObject traveler = candyMatrix[dropedCor.x, dropedCor.y];
            //Doing the movement
            LeanTween.move(traveler, destination, 0.2f).setOnComplete(() =>
            {
                //End of movement
                canPlay = true;
            })
            .setEaseOutExpo();
        }

        IEnumerator CandyGoesHome(Vector2Int dropedCor)
        {
            canPlay = false;
            Debug.Log("Candy returning to original position");
            bool notHome = true;
            //Vector3 destination = grid.CellToWorld(new Vector3Int(dropedCor.x, dropedCor.y, 0)) + grid.cellSize / 2;
            Vector3 destination = picksAndDrops.destination;
            GameObject traveler = candyMatrix[dropedCor.x, dropedCor.y];
            while (notHome)
            {
                Vector3 dir = (destination) - traveler.transform.position;
                traveler.transform.position += dir * Time.deltaTime * 10;
                if (dir.magnitude <= 0.01f)
                {
                    traveler.transform.position = destination;
                    notHome = false;
                }
                yield return null;
            }
            canPlay = true;
        }

        void CandySwapsHome2(Vector4 pickedFrom)
        {
            //Initializing candy swap
            canPlay = false;
            Debug.Log("Two candies are switching places 2");
            //Making variables for easier use
            Vector3 destination1 = grid.CellToWorld(new Vector3Int((int)pickedFrom.z, (int)pickedFrom.w, 0)) + grid.cellSize / 2;
            Vector3 destination2 = grid.CellToWorld(new Vector3Int((int)pickedFrom.x, (int)pickedFrom.y, 0)) + grid.cellSize / 2;
            GameObject candy1 = candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y];
            GameObject candy2 = candyMatrix[(int)pickedFrom.z, (int)pickedFrom.w];
            //Making the swap
            LeanTween.move(candy1, destination1, 0.2f).setEaseLinear();
            LeanTween.move(candy2, destination2, 0.2f).setOnComplete(() =>
            {
                //End of execution
                //UpdateCandyMatrix();
                SwapCandyMatrix((int)pickedFrom.x, (int)pickedFrom.y, (int)pickedFrom.z, (int)pickedFrom.w);
                makeMap.ClearMap();
                makeMap.UpdateVisualizer();
                OnCandiesDestroyed();
                canPlay = true;
            }).setEaseLinear();
            
        }

        IEnumerator CandySwapsHome(Vector4 pickedFrom)
        {
            canPlay = false;
            Debug.Log("Two candies are swaping places");
            bool notHome1 = true, notHome2 = true;
            Vector3 destination1 = grid.CellToWorld(new Vector3Int((int)pickedFrom.z, (int)pickedFrom.w, 0)) + grid.cellSize / 2;
            Vector3 destination2 = grid.CellToWorld(new Vector3Int((int)pickedFrom.x, (int)pickedFrom.y, 0)) + grid.cellSize / 2;
            GameObject candy1 = candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y];
            GameObject candy2 = candyMatrix[(int)pickedFrom.z, (int)pickedFrom.w];
            while (notHome1 || notHome2)
            {
                if (notHome1)
                {
                    Vector3 dir = (destination1) - candy1.transform.position;
                    candy1.transform.position += dir * Time.deltaTime * 10;
                    if (dir.magnitude <= 0.01f)
                    {
                        candy1.transform.position = destination1;
                        notHome1 = false;
                    }
                }
                if (notHome2)
                {
                    Vector3 dir = (destination2) - candy2.transform.position;
                    candy2.transform.position += dir * Time.deltaTime * 10;
                    if (dir.magnitude <= 0.01f)
                    {
                        candy2.transform.position = destination2;
                        notHome2 = false;
                    }
                }
                yield return null;
            }
            UpdateCandyMatrix();
            makeMap.ClearMap();
            makeMap.UpdateVisualizer();
            OnCandiesDestroyed();
            canPlay = true;
        }

        void CandyDropsDown2(Vector4 pickedFrom)
        {
            //Making variables for easier use
            Vector3 destination1 = grid.CellToWorld(new Vector3Int((int)pickedFrom.z, (int)pickedFrom.w, 0)) + grid.cellSize / 2;
            GameObject candy1 = candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y];

            LeanTween.move(candy1, destination1, fallVelocity).setEaseOutBounce();

        }

        IEnumerator CandyDropsDown(Vector4 pickedFrom)
        {
            bool notHome1 = true;
            Vector3 destination1 = grid.CellToWorld(new Vector3Int((int)pickedFrom.z, (int)pickedFrom.w, 0)) + grid.cellSize / 2;
            float v = 0;
            GameObject candy1 = candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y];
            while (notHome1)
            {
                Vector3 dir = (destination1) - candy1.transform.position;
                candy1.transform.position += dir.normalized * v * Time.deltaTime;
                if (candy1.transform.position.y <= destination1.y)
                {
                    candy1.transform.position = destination1;
                    notHome1 = false;
                }
                v += candyFallAccel;
                canPlay = false;
                yield return null;
            }
            candyDropFallbackCount++;
            if (candyDropFallbackCount >= candyDropFallback)
            {
                Debug.Log("candyDrop callback");
                UpdateCandyMatrix();
                makeMap.OnCandyDropFinish();
                canPlay = true;
            }
        }
    }
}

/*TODO:
    - Cambio a gameobjects en lugar d matrix en candy drops down
 */
