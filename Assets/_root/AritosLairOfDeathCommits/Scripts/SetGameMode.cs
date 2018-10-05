using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos
{
    public class SetGameMode : MonoBehaviour
    {
        private ModeGame m_gamemodeSet;
        private string m_savename;
        public bool isLoading = false;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public string getSavename()
        {
            return m_savename;
        }

        public void SetSavename(InputField _nameInput)
        {
            m_savename = _nameInput.GetComponent<InputField>().text;
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

        public void LoadSave(string _savename)
        {
            m_savename = _savename;
            isLoading = true;
            Manager_Static.sceneManager.LoadScene(1);
        }

        public void DestroyTheChild()
        {
            Destroy(this.gameObject);
        }
    }
}