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
        public GameObject gameZone;

        private Grid grid;

        //Testing
        public Camera cam;
        public GameObject p;
        public int x, y, z;

        // Use this for initialization
        void Start()
        {
            grid = GetComponent<Grid>();
            Vector3 cellSize = grid.cellSize;

            for(int i = 0; i < candies.Length; i++)
            {
                PoolManager.MakePool(candies[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //Testing
            p.transform.position = grid.GetCellCenterLocal(new Vector3Int(x, y, z));
        }
    }
}

/*TODO:
    Que se pongan en el lugar que se    
 */
