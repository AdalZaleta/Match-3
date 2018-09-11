using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos
{
    public class Manager_Saves : MonoBehaviour
    {
        public GameObject newFileUI;
        public GameObject saveList;
        public GameObject savePrefab;
        DirectoryInfo di;

        private string m_selectedSave;

        private void Awake()
        {
            Manager_Static.savesManager = this;
            // Set Savefiles Directory
            di = new DirectoryInfo(@"Assets/_root/Resources/Saves/");
            LoadSaveList();
        }

        // Toggles Text Input Menu
        public void ToggleNewFileUI(bool _bool)
        {
            newFileUI.SetActive(_bool);
        }

        // Creates empty txt file @ Resources/Saves with name given by input field
        public void CreateSavefile(InputField inputField)
        {
            // Create new txt file with name 'savename' at _root > Resources > Saves
            File.WriteAllText("Assets/_root/Resources/Saves/" + inputField.text + ".txt", "");
            newFileUI.SetActive(false);
            LoadSaveList();
        }

        // Gets data from game objects and stores them in it's corresponding savefile
        public void SaveGame()
        {
            // Get data from game
            // Save data to txt file with name
        }

        // Loads data from corresponding txt file and sets them in-game
        public void LoadGame(string _savename)
        {
            // Get Savename
            // Get data from txt file named '_savename' from _root > Resources > Saves
            // Set values in-game from savefile
        }

        // Loads all savefile names from Resources/Saves and lists them
        public void LoadSaveList()
        {
            // Get number of txt files in _root > Resources > Saves
            // List saves using '_savename' as name as buttons

            // Get All Files in Resources/Saves Directory
            long _i = 0;
            FileInfo[] fis = di.GetFiles();
            foreach (FileInfo fi in fis)
            {
                if (fi.Extension.Contains("txt"))
                {
                    // For Each File in Resources/Saves
                    GameObject save = Instantiate(savePrefab, saveList.transform); // Instantiate Button
                    save.GetComponent<RectTransform>().anchoredPosition = new Vector3(195, -115 - (50 * _i), 0); // Reposition Button
                    save.GetComponentInChildren<Text>().text = fi.Name.Split('.')[0]; // Rename Button

                    // Set OnClick Method to LoadGame(_savename) with _savename as the button's text value

                    _i++;
                }
            }
        }
    }
}