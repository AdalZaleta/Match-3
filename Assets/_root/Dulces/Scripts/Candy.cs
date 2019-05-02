using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class Candy : MonoBehaviour
    {

        public GameObject particles;
        // Use this for initialization
        void Start()
        {
            if (particles != null)
                PoolManager.PreSpawn(particles, 1, true);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnDespawn()
        {
            if (particles != null)
                PoolManager.Spawn(particles, transform.position, Quaternion.identity);

            transform.position = Vector3.zero;
        }
    }
}