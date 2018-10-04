using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        public Text scoreNum;
        public Text timeVal;
        public Animator catAnim;

        private void Awake()
        {
            Manager_Static.gameStateManager = this;
        }

        private void Start()
        {
            scoreNum.text = m_score.ToString();
        }

        void Update()
        {
            //AQUI SE ENCUENTRA EL CÓDIGO DEPENDIENDO DEL GAME MODE

            //Game Mode ENDLESS
            if(Manager_Static.gameModeManager.currentGameState == ModeGame.ENDLESS)
            {
                EndlessGame();
                Score();
            }

            //Game Mode de MOVIMIENTOS LIMITADOS
            else if (Manager_Static.gameModeManager.currentGameState == ModeGame.MOVE_LIMIT)
            {
                LimitedMoves();
                Score();
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
                Score();
                timeVal.text = time.ToString();
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
            scoreNum.text = m_actualScore.ToString();
        }

        public void LimitedTime()
        {
            time -= Time.deltaTime;
        }

        public void AddScore(int _scoreToAdd)
        {
            if (_scoreToAdd == 3)
            {
                _scoreToAdd = _scoreToAdd * 2;
                time = time + timeToAdd;
                catAnim.SetTrigger("Match");
            }
            else if (_scoreToAdd == 4 || _scoreToAdd == 5)
            {
                _scoreToAdd = _scoreToAdd * 4;
                time = time + timeToAdd;
                catAnim.SetTrigger("Match");
            }
            else if (_scoreToAdd >= 6)
            {
                _scoreToAdd = _scoreToAdd * 10;
                time = time + timeToAdd;
                catAnim.SetTrigger("Match");
            }
            else if (_scoreToAdd >= 2)
                Application.Quit();


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