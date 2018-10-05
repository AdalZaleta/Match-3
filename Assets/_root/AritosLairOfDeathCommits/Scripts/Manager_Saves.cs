using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos
{
    public class Manager_Saves : MonoBehaviour
    {
        public GameObject saveList;
        public GameObject savePrefab;
        public GameObject delPrefab;
        public GameObject grid;
        public GameObject Score;
        DirectoryInfo di;

        private string m_selectedSave;
        private GameObject thicc;

        private void Awake()
        {
            Manager_Static.savesManager = this;
            // Set Savefiles Directory
            di = new DirectoryInfo(@"Assets/_root/Resources/Saves/");
            thicc = GameObject.Find("ThickLoad");
            m_selectedSave = thicc.GetComponent<SetGameMode>().getSavename();
            if (thicc.GetComponent<SetGameMode>().isLoading)
            {
                if (grid)
                {
                    grid.GetComponent<MakeMap>().isLoading = true;
                }
            }
        }

        private void Start()
        {
            if (thicc.GetComponent<SetGameMode>().isLoading)
            {
                LoadGame(m_selectedSave);
            }
        }

        public void DestroyThicc()
        {
            thicc.GetComponent<SetGameMode>().DestroyTheChild();
        }

        // Creates empty txt file @ Resources/Saves with name given by input field
        public void CreateSavefile(InputField inputField)
        {
            // Create new txt file with name 'savename' at _root > Resources > Saves
            File.WriteAllText("Assets/_root/Resources/Saves/" + inputField.text + ".txt", "");
            m_selectedSave = inputField.text;
        }

        public void DeleteSave(string _savename)
        {
            File.Delete("Assets/_root/Resources/Saves/" + _savename + ".txt");
            LoadSaveList();
        }

        // Gets data from game objects and stores them in it's corresponding savefile
        public void SaveGame()
        {
            using (var stream = new FileStream("Assets/_root/Resources/Saves/" + m_selectedSave + ".txt", FileMode.Truncate))
            {
                using (var clearWriter = new StreamWriter(stream))
                {
                    clearWriter.Write("");
                }
            }

            StreamWriter writer = new StreamWriter("Assets/_root/Resources/Saves/" + m_selectedSave + ".txt", true);
            writer.WriteLine(Score.GetComponent<Text>().text);

            string gridValues = "";

            for (int i = 0; i < grid.GetComponent<MakeMap>().elemento.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetComponent<MakeMap>().elemento.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                        gridValues = gridValues + grid.GetComponent<MakeMap>().GetElement(i, j);
                    else
                        gridValues = gridValues + " " + grid.GetComponent<MakeMap>().GetElement(i, j);
                }
            }

            writer.WriteLine(gridValues);
            writer.Close();
        }

        // Loads data from corresponding txt file and sets them in-game
        public void LoadGame(string _savename)
        {
            m_selectedSave = _savename;
            grid.GetComponent<MakeMap>().ClearMap();

            if (new FileInfo("Assets/_root/Resources/Saves/" + m_selectedSave + ".txt").Length == 0)
            {
                Debug.Log("This wasn't supposed to happen");
            } else
            {
                StreamReader reader = new StreamReader("Assets/_root/Resources/Saves/" + m_selectedSave + ".txt");
                int lineCounter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    switch (lineCounter)
                    {
                        case 0:
                            Score.GetComponent<Text>().text = line;
                            break;

                        case 1:
                            int[] arrValues = Array.ConvertAll(line.Split(' '), int.Parse);

                            int idValues = 0;
                            for (int i = 0; i < grid.GetComponent<MakeMap>().filas; i++)
                            {
                                for (int j = 0; j < grid.GetComponent<MakeMap>().columnas; j++)
                                {
                                    Debug.Log("Usage of elemento");
                                    grid.GetComponent<MakeMap>().SetElement(i, j, arrValues[idValues]);
                                    idValues++;
                                }
                            }
                            break;

                        default:
                            Debug.Log("Something Went Wrong");
                            break;
                    }
                    lineCounter++;
                }
                reader.Close();
            }
            grid.GetComponent<MakeMap>().setupElem();
        }

        // Loads all savefile names from Resources/Saves and lists them
        public void LoadSaveList()
        {
            // Get number of txt files in _root > Resources > Saves
            // List saves using '_savename' as name as buttons

            // Get All Files in Resources/Saves Directory

            foreach (Transform child in saveList.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            long _i = 0;
            FileInfo[] fis = di.GetFiles();
            foreach (FileInfo fi in fis)
            {
                if (fi.Extension.Contains("txt"))
                {
                    // For Each File in Resources/Saves
                    GameObject save = Instantiate(savePrefab, saveList.transform); // Instantiate Button
                    save.GetComponent<RectTransform>().anchoredPosition = new Vector3(-75, -115 - (100 * _i), 0); // Reposition Button
                    save.GetComponentInChildren<Text>().text = fi.Name.Split('.')[0]; // Rename Button

                    GameObject del = Instantiate(delPrefab, saveList.transform);
                    del.GetComponent<RectTransform>().anchoredPosition = new Vector3(165, -115 - (100 * _i), 0);

                    // Set OnClick Method to LoadGame(_savename) with _savename as the button's text value
                    save.GetComponent<Button>().onClick.AddListener(delegate { thicc.GetComponent<SetGameMode>().LoadSave(save.GetComponentInChildren<Text>().text); });
                    del.GetComponent<Button>().onClick.AddListener(delegate { DeleteSave(save.GetComponentInChildren<Text>().text); });

                    _i++;
                }
            }
        }
    }
}