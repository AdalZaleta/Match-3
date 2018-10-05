using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class Manager_GameMode : MonoBehaviour
    {
        public ModeGame currentGameState;

        private void Awake()
        {
            Manager_Static.gameModeManager = this;
            GameObject getGM = GameObject.Find("SetGameMode");
            currentGameState = getGM.GetComponent<SetGameMode>().getGameMode();
        }

        public void SetEndless()
        {
            Manager_Static.gameModeManager.currentGameState = ModeGame.ENDLESS;
        }

        public void SetScore()
        {
            Manager_Static.gameModeManager.currentGameState = ModeGame.POINTS;
        }

        public void SetLimitedTime()
        {
            Manager_Static.gameModeManager.currentGameState = ModeGame.TIMEBASED;
        }

        public void SetLimitedMoves()
        {
            Manager_Static.gameModeManager.currentGameState = ModeGame.MOVE_LIMIT;
        }
    }
}
