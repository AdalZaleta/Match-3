using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class Manager_UI : MonoBehaviour
    {
        public GameObject loadSavePanel;
        public GameObject newSavePanel;
        public GameObject loadingPanel;

        private void Awake()
        {
            Manager_Static.uiManager = this;
        }
        public void ToggleLoadSavePanel(bool _bool)
        {
            loadSavePanel.SetActive(_bool);
        }
        public void ToggleNewSavePanel(bool _bool)
        {
            newSavePanel.SetActive(_bool);
        }
        public void ToggleLoadingPanel(bool _bool)
        {
            loadingPanel.SetActive(_bool);
        }
    }
}