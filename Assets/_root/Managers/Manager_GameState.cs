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
        private bool m_end = false;

        public int moves;
        public float time;
        public float timeToAdd;
        public Text scoreNum;
        public Text timeVal;
        public Text movesVal;
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
            if (!m_end)
            {
                //Game Mode ENDLESS
                if (Manager_Static.gameModeManager.currentGameState == ModeGame.ENDLESS)
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
                    if (m_actualScore >= 1000)
                        OnWin();
                }

                //Game Mode de LIMITED TIME
                else if (Manager_Static.gameModeManager.currentGameState == ModeGame.TIMEBASED)
                {
                    LimitedTime();
                    Score();
                    timeVal.text = time.ToString().Substring(0, 2);
                    if (time <= 0)
                        OnLose();
                }
            }
        }

        public void OnWin()
        {
            Manager_Static.appManager.SetScores();
            Manager_Static.audioManager.PlaySoundGlobal(sounds.WIN);
            Manager_Static.scoreManager.ToggleEndMenu(true);
            m_end = true;
        }

        public void OnLose()
        {
            Manager_Static.appManager.SetScores();
            Manager_Static.audioManager.PlaySoundGlobal(sounds.LOSE);
            Manager_Static.scoreManager.ToggleEndMenu(true);
            m_end = true;
        }

        public void EndlessGame()
        {

        }

        public void LimitedMoves()
        {
            movesVal.text = moves.ToString();
            if (moves <= 0)
                OnWin();
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
                moves--;
                Manager_Static.audioManager.PlaySoundGlobal(sounds.NORMAL_MATCH);
            }
            else if (_scoreToAdd == 4 || _scoreToAdd == 5)
            {
                _scoreToAdd = _scoreToAdd * 4;
                time = time + timeToAdd;
                catAnim.SetTrigger("Match");
                moves--;
                Manager_Static.audioManager.PlaySoundGlobal(sounds.SPECIAL_MATCH);
            }
            else if (_scoreToAdd >= 6)
            {
                _scoreToAdd = _scoreToAdd * 10;
                time = time + timeToAdd;
                catAnim.SetTrigger("Match");
                moves--;
                Manager_Static.audioManager.PlaySoundGlobal(sounds.SPECIAL_MATCH);
                Manager_Static.audioManager.PlaySoundGlobal(sounds.SPECIAL_MATCH);
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