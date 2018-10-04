using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class Manager_GameState : MonoBehaviour
    {
        private int m_score = 0;
        private int m_actualScore = 0;
        private int m_movesMaded = 0;

        public int moves;
        public float time;
        public float timeToAdd;

        private void Awake()
        {
            Manager_Static.gameStateManager = this;
        }

        void Update()
        {
            //AQUI SE ENCUENTRA EL CÓDIGO DEPENDIENDO DEL GAME MODE

            //Game Mode ENDLESS
            if(Manager_Static.gameModeManager.currentGameState == ModeGame.ENDLESS)
            {
                EndlessGame();
            }

            //Game Mode de MOVIMIENTOS LIMITADOS
            else if (Manager_Static.gameModeManager.currentGameState == ModeGame.MOVE_LIMIT)
            {
                LimitedMoves();
            }

            //Game Mode de SCORE
            else if (Manager_Static.gameModeManager.currentGameState == ModeGame.POINTS)
            {
                Score();
            }

            //Game Mode de LIMITED TIME
            else if (Manager_Static.gameModeManager.currentGameState == ModeGame.TIMEBASED)
            {
                LimitedTime();
            }
        }

        public void EndlessGame()
        {

        }

        public void LimitedMoves()
        {
            
        }

        public void Score()
        {
            
        }

        public void LimitedTime()
        {
            time -= Time.deltaTime;
        }

        private void AddScore(int _scoreToAdd)
        {
            m_actualScore = m_actualScore + _scoreToAdd;
        }

        public int GetScore()
        {
            return m_actualScore;
        }

        public void MoveMaded(bool _moveMaded)
        {
            if(_moveMaded == true)
            {
                if (Manager_Static.gameModeManager.currentGameState == ModeGame.TIMEBASED)
                    moves--;
                else if (Manager_Static.gameModeManager.currentGameState == ModeGame.TIMEBASED)
                    time = time + timeToAdd; 
            }
        }
    }
}