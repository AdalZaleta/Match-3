using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class SetGameMode : MonoBehaviour
    {
        private ModeGame m_gamemodeSet;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public ModeGame getGameMode()
        {
            return m_gamemodeSet;
        }

        public void SetGM(int _index)
        {
            switch (_index)
            {
                case 0:
                    m_gamemodeSet = ModeGame.POINTS;
                    break;

                case 1:
                    m_gamemodeSet = ModeGame.TIMEBASED;
                    break;

                case 2:
                    m_gamemodeSet = ModeGame.MOVE_LIMIT;
                    break;

                case 3:
                    m_gamemodeSet = ModeGame.ENDLESS;
                    break;
            }
            
        }
    }
}