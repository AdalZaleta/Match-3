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
        }

        public void Setup(int[,] mat) //This is called by MakeMap
        {
            PoolManager.ClearPools();
            matrix = mat;
            width = matrix.GetLength(0);
            height = matrix.GetLength(1);
            candyMatrix = new GameObject[width, height];

            for (int i = 0; i < candies.Length; i++)
            {
                PoolManager.MakePool(candies[i], 500);
                
            }
            RedrawGrid();
        }

        void Update()
        {
           
        }

        public void UpdateMatrix(int[,] mat) //This is called by MakeMap
        {
            matrix = mat;
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
            //Debug.Log("Swaping (" + x1 + ", " + y1 + ") with (" + x2 + ", " + y2 + ")");
            GameObject temp = candyMatrix[x1, y1];
            candyMatrix[x1, y1] = candyMatrix[x2, y2];
            candyMatrix[x2, y2] = temp;
        }

        void ClearCandyMatrix()
        {
            Debug.Log("Clearing CandyMatrix");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        candyMatrix[i, j] = null;

                }
            }
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
            //Debug.Log("picked: " + picked);
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
                //Debug.Log("Candy Dropped On: " + droppedOn);
                if (droppedOn.x >= 0 && droppedOn.y >= 0 && droppedOn.x < width && droppedOn.y < height) //if en donde pregunto que rollo con los matches
                {
                    if (makeMap.MakeMove(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y)) //Entro si esque se hace un match
                    {
                        //Debug.Break();
                        canPlay = false;
                        CandySwapsHome2(new Vector4(picksAndDrops.pickedCor.x, picksAndDrops.pickedCor.y, droppedOn.x, droppedOn.y));
                    }
                    else
                    {
                        CandyGoesHome2(picksAndDrops.pickedCor);
                    }
                }
                else
                {
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
                    if (candyMatrix[i, j] != null)
                    {
                        if (matrix[i, j] == 0 && candyMatrix[i, j].activeSelf)
                        {
                            PoolManager.Despawn(candyMatrix[i, j]);
                            candyMatrix[i, j] = null;
                            //Debug.Log("Destroyed i,j: " + i + ", " + j);
                        }
                    }
                }
            }
        }

        public void OnCandiesDestroyed()
        {
            canPlay = false;
            //UpdateCandyMatrix();
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

                        if (candyMatrix[moveMap[i, j].x, moveMap[i, j].y] != null)
                        {
                            CandyDropsDown2(new Vector4(moveMap[i, j].x, moveMap[i, j].y, i, j));
                            atLeastOneDrop = true;
                        }

                        candyDropFallback++;
                    }
                }
            }
            if (!atLeastOneDrop)
            {
                //UpdateCandyMatrix();
                makeMap.OnCandyDropFinish(); //Llama OnCandiesDestroyed o SpawnNewCandies 
            }
            else
            {
                Invoke("OnCandyFallFinish", fallVelocity + 0.05f);
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
                        Debug.Log("news[i, j] = " + news[i, j]);
                        Debug.Log("candies[news[i, j]] " + candies[news[i, j]]);

                        Transform temp = PoolManager.Spawn(candies[news[i, j]], grid.CellToWorld(new Vector3Int(i, j + height, 0)) + grid.cellSize / 2, Quaternion.identity); ;
                        Debug.Log("Transform: " + temp);

                        candyMatrix[i, j] = temp.gameObject;

                        candyDropFallback++;
                        CandyDropsDown2(new Vector4(i, j, i, j));
                    }
                }
            }

            if (atLeastOneDrop)
                Invoke("OnCandyFallFinish", fallVelocity + 0.05f);
            else
                canPlay = true;
        }

        void OnCandyFallFinish()
        {
            Debug.Log("candyDrop callback");
            ClearCandyMatrix();
            makeMap.OnCandyDropFinish(); //Llama OnCandiesDestroyed si hubo matches
            
        }

        void CandyGoesHome2(Vector2Int dropedCor)
        {
            //Initializing 
            //Debug.Log("Candy returning to original position 2");
            //Declaring variables for easier use
            Vector3 destination = picksAndDrops.destination;
            GameObject traveler = candyMatrix[dropedCor.x, dropedCor.y];
            //Doing the movement
            LeanTween.move(traveler, destination, 0.2f).setEaseOutExpo();
        }

        void CandySwapsHome2(Vector4 pickedFrom)
        {
            //Initializing candy swap
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
                OnCandiesDestroyed();
            }).setEaseLinear();
        }

        void CandyDropsDown2(Vector4 pickedFrom)
        {
            //Making variables for easier use
            Vector3 destination1 = grid.CellToWorld(new Vector3Int((int)pickedFrom.z, (int)pickedFrom.w, 0)) + grid.cellSize / 2;
            GameObject candy1 = candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y];

            LeanTween.move(candy1, destination1, fallVelocity).setEaseOutBounce().setOnComplete(() =>
            {
                //Debug.Log("Setting value in (" + (int)pickedFrom.z + ", " + (int)pickedFrom.w + ") as the one in (" + (int)pickedFrom.x + ", " + (int)pickedFrom.y + ")");
                candyMatrix[(int)pickedFrom.z, (int)pickedFrom.w] = candyMatrix[(int)pickedFrom.x, (int)pickedFrom.y];
            });
        }
    }
}
