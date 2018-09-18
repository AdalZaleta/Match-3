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

        //Testing
        public int x, y, z;
        private int[][] matrix;

        void Start()
        {
            matrix = new int[width][];
            for(int i = 0; i < width; i++)
            {
                matrix[i] = new int[height];
                //this is for thessthingg
                for(int j = 0; j < height; j++)
                {
                    matrix[i][j] = Random.Range(0, candies.Length-1);
                }
            }


            for(int i = 0; i < candies.Length; i++)
            {
                PoolManager.MakePool(candies[i]);
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
                    matrix[i][j] = Random.Range(0, candies.Length-1);
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
                    Debug.Log(candies.Length + ", and " + matrix[i][j]);
                    Transform candy = PoolManager.Spawn(candies[matrix[i][j]], grid.CellToWorld(new Vector3Int(i, j, 0)) + grid.cellSize/2, Quaternion.identity);
                }
            }
        }

        

        public void OnCandyPicked()
        {

        }

        public void OnCandyHover()
        {
            //Por ahora no hace nada
        }

        public void OnCandyDropped()
        {

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

    }
}

/*TODO:
    Pues hay un error que arreglar
 */
