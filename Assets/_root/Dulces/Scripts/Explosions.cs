using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class Explosions : MonoBehaviour
    {
        public ParticleSystem ps;
        bool tryToStop = false;

        private void Start()
        {
            ps = GetComponent<ParticleSystem>();
        }

        private void Update()
        {
            if (!ps.IsAlive() && tryToStop)
                SelfDespawn();
        }

        void OnSpawn()
        {
            tryToStop = true;
            if (ps != null)
            {
                ps.Play();
            }
        }

        void SelfDespawn()
        {
            PoolManager.Despawn(gameObject);
        }

        void OnDespawn()
        {
            tryToStop = false;
        }
    }
}