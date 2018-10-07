using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

/* TO DO
 * Limit Scores to 5 per gamemode
 * Sort Scores when new one is added
 */

namespace Mangos
{
    public class Manager_Scores : MonoBehaviour {

        public GameObject prefab;
        public GameObject panel;
        public GameObject inputPanel;
        public GameObject backButt;
        private int m_newScore;
        private string m_newName;

        private void Awake()
        {
            Manager_Static.scoreManager = this;
        }

        public void ToggleEndMenu(bool _bool)
        {
            inputPanel.SetActive(_bool);
        }

        public void SetName(GameObject _inputBox)
        {
            m_newName = _inputBox.GetComponent<InputField>().text;
            inputPanel.SetActive(false);
            panel.SetActive(true);
            backButt.SetActive(true);
            SetScore(Manager_Static.gameStateManager.GetScore());
            SaveScore();
        }

        public void SetScore(int _score)
        {
            m_newScore = _score;
        }

        public void SaveScore()
        {
            string modeName = "";
            
            switch (Manager_Static.gameModeManager.currentGameState)
            {
                case ModeGame.POINTS:
                    modeName = "Points";
                    break;

                case ModeGame.TIMEBASED:
                    modeName = "Time";
                    break;

                case ModeGame.MOVE_LIMIT:
                    modeName = "Limit";
                    break;

                case ModeGame.ENDLESS:
                    modeName = "Endless";
                    break;
            }
            
            // DEPRECATED
            /*
            if (File.Exists("Assets/_root/Resources/Scores/"+modeName+"_score.txt"))
            {
                // Save New Score (writer)
                StreamWriter writer = new StreamWriter("Assets/_root/Resources/Scores/" + modeName + "_score.txt", true);
                writer.WriteLine(m_newName + " " +m_newScore.ToString());
                writer.Close();

                // Declaration of Arrays
                string[] ogNames = new string[6];
                int[] ogScores = new int[6];
                string[] sortedNames = new string[6];
                int[] sortedScores = new int[6];
                bool[] usedScore = { false, false, false, false, false, false };

                // Check New Number of Scores
                // Setting Original Array Values
                StreamReader reader = new StreamReader("Assets/_root/Resources/Scores/" + modeName + "_score.txt");
                int lineCounter = 0;
                while (!reader.EndOfStream && lineCounter < 6)
                {
                    string line = reader.ReadLine();
                    string[] lineArr = line.Split(' ');
                    // Set Values for og Names & Values and pre-sortedScores
                    ogNames[lineCounter] = lineArr[0];
                    ogScores[lineCounter] = int.Parse(lineArr[1]);
                    sortedScores[lineCounter] = int.Parse(lineArr[1]);
                    lineCounter++;
                }
                reader.Close();

                // Trim sortedScore's Length to Fit Current Scores and Update sortedNames' Length
                bool foundNull = false;
                for (int i = 0; i < sortedScores.Length; i++)
                {
                    if (sortedScores[i] == 0 && !foundNull)
                    {
                        Array.Resize(ref sortedScores, i);
                        Array.Resize(ref sortedNames, i);
                        foundNull = true;
                    }
                }

                // Sort Scores
                Array.Sort(sortedScores);
                Array.Reverse(sortedScores);

                // Trim if more than 5 values in array
                if (!foundNull)
                {
                    Array.Resize(ref sortedScores, 5);
                    Array.Resize(ref sortedNames, 5);
                }

                // Link Names to Corresponding Score
                for (int i = 0; i < sortedScores.Length; i++)
                {
                    bool setName = false;
                    for (int j = 0; j < ogScores.Length; j++)
                    {
                        if ((sortedScores[i] == ogScores[j]) && !usedScore[j] && !setName)
                        {
                            sortedNames[i] = ogNames[j];
                            usedScore[j] = true;
                            setName = true;
                        }
                    }
                }

                // Clear Score File
                using (var stream = new FileStream("Assets/_root/Resources/Scores/" + modeName + "_score.txt", FileMode.Truncate))
                {
                    using (var writerClear = new StreamWriter(stream))
                    {
                        writerClear.Write("");
                    }
                }

                // Add Sorted Data to Text File
                StreamWriter writerSorted = new StreamWriter("Assets/_root/Resources/Scores/" + modeName + "_score.txt", true);
                for (int i = 0; i < sortedScores.Length; i++)
                {
                    writerSorted.WriteLine(sortedNames[i] + " " + sortedScores[i].ToString());
                }
                writerSorted.Close();
            }
            else
            {
                File.WriteAllText("Assets/_root/Resources/Scores/" + modeName + "_score.txt", "");
                StreamWriter writer = new StreamWriter("Assets/_root/Resources/Scores/" + modeName + "_score.txt", true);
                writer.WriteLine(m_newName + " " + m_newScore.ToString());
                writer.Close();
            }
            */

            if (PlayerPrefs.HasKey(modeName + "_scores"))
            {
                // Save New Score
                PlayerPrefs.SetString(modeName + "_name", PlayerPrefs.GetString(modeName + "_name") + " ");
                PlayerPrefs.SetString(modeName + "_score", PlayerPrefs.GetInt(modeName + "_score").ToString() + " ");

                // Sorting Arrays
                string[] ogNames = new string[6];
                int[] ogScores = new int[6];
                string[] sortedNames = new string[6];
                int[] sortedScores = new int[6];
                bool[] usedScore = { false, false, false, false, false, false };

                // Check New Number of Scores
                // Setting Original Array Values
                for (int i = 0; i < 6; i++) {
                    string[] scoresArr = PlayerPrefs.GetString(modeName + "_score").Split(' ');
                    string[] namesArr = PlayerPrefs.GetString(modeName + "_name").Split(' ');
                    // Set Values for og Names & Values and pre-sortedScores
                    ogNames[i] = namesArr[i];
                    ogScores[i] = int.Parse(scoresArr[i]);
                    sortedScores[i] = int.Parse(scoresArr[i]);
                }

                // Trim sortedScore's Length to Fit Current Scores and Update sortedNames' Length
                bool foundNull = false;
                for (int i = 0; i < sortedScores.Length; i++)
                {
                    if (sortedScores[i] == 0 && !foundNull)
                    {
                        Array.Resize(ref sortedScores, i);
                        Array.Resize(ref sortedNames, i);
                        foundNull = true;
                    }
                }

                // Sort Scores
                Array.Sort(sortedScores);
                Array.Reverse(sortedScores);

                // Trim if more than 5 values in array
                if (!foundNull)
                {
                    Array.Resize(ref sortedScores, 5);
                    Array.Resize(ref sortedNames, 5);
                }

                // Link Names to Corresponding Score
                for (int i = 0; i < sortedScores.Length; i++)
                {
                    bool setName = false;
                    for (int j = 0; j < ogScores.Length; j++)
                    {
                        if ((sortedScores[i] == ogScores[j]) && !usedScore[j] && !setName)
                        {
                            sortedNames[i] = ogNames[j];
                            usedScore[j] = true;
                            setName = true;
                        }
                    }
                }

                // Set Names and Scores to single Strings
                string sortedN = "";
                string sortedS = "";
                for (int i = 0; i < 6; i++)
                {
                    sortedN += sortedNames[i] + " ";
                    sortedS += sortedScores[i] + " ";
                }

                PlayerPrefs.SetString(modeName + "_name", sortedN);
                PlayerPrefs.SetString(modeName + "_score", sortedS);

            } else
            {
                PlayerPrefs.SetString(modeName + "_name", m_newName + " ");
                PlayerPrefs.SetString(modeName + "_score", m_newScore.ToString() + " ");
            }

            ListScores();
        }

        public void ListScores()
        {
            string modeName = "";
            switch (Manager_Static.gameModeManager.currentGameState)
            {
                case ModeGame.POINTS:
                    modeName = "Points";
                    break;

                case ModeGame.TIMEBASED:
                    modeName = "Time";
                    break;

                case ModeGame.MOVE_LIMIT:
                    modeName = "Limit";
                    break;

                case ModeGame.ENDLESS:
                    modeName = "Endless";
                    break;
            }

            // DEPRECATED
            /*
            if (File.Exists("Assets/_root/Resources/Scores/" + modeName + "_score.txt"))
            {
                foreach(Transform child in panel.transform)
                {
                    Destroy(child.gameObject);
                }
                StreamReader reader = new StreamReader("Assets/_root/Resources/Scores/" + modeName + "_score.txt");
                int lineCounter = 0;
                while (!reader.EndOfStream && lineCounter < 5)
                {
                    string line = reader.ReadLine();
                    string[] lineArr = line.Split(' ');
                    GameObject go = Instantiate(prefab, panel.transform);
                    go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -100 -(lineCounter * 60));
                    go.GetComponentInChildren<Text>().text = (lineCounter + 1) + " |    " + lineArr[0] + "  :  " + lineArr[1];
                    lineCounter++;
                }
                reader.Close();
            }
            else
            {
                Debug.Log("No Scores To List");
            }
            */

            foreach (Transform child in panel.transform)
            {
                Destroy(child.gameObject);
            }

            string[] namesArr = PlayerPrefs.GetString(modeName + "_name").Split(' ');
            string[] scoresArr = PlayerPrefs.GetString(modeName + "_score").Split(' ');
            for (int i = 0; i < namesArr.Length; i++)
            {
                GameObject go = Instantiate(prefab, panel.transform); // Instantiate Score
                go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -100 - (i * 60)); // Reposition Score
                go.GetComponentInChildren<Text>().text = i + " |    " + namesArr[i] + "  :  " + scoresArr[i];
            }
        }
    }
}