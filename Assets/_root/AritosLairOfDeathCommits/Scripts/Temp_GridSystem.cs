using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class Temp_GridSystem : MonoBehaviour
    {

        public int gridWidth;
        public int gridHeight;
        public int[,] grid;
        public GameObject[] elements;
        public GameObject gridStart;

        private void Start()
        {
            grid = new int[gridWidth, gridHeight];
        }

        public void ClearGrid()
        {
            foreach (Transform child in gridStart.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        private GameObject selectPrefab(int _id)
        {
            return elements[_id - 1];
        }

        public void InstantiateGrid()
        {
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = 0; j < gridHeight; j++)
                {
                    Instantiate(selectPrefab(grid[i, j]), new Vector3(gridStart.transform.position.x + i, gridStart.transform.position.y + j, 0), Quaternion.identity, gridStart.transform);
                }
            }
        }

        public void SetGridValue(int _x, int _y, int _value)
        {
            grid[_x, _y] = _value;
        }

        public int getGridValue(int _x, int _y)
        {
            return grid[_x, _y];
        }
    }
}