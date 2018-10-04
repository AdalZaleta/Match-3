using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_UI : MonoBehaviour {

    public GameObject score;

    private int m_currentScore;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            AddScore(10);
        }
    }

    public void SetScore(int _score)
    {
        m_currentScore = _score;
    }

    public void AddScore(int _score)
    {
        m_currentScore += _score;
    }

    public int GetScore()
    {
        return m_currentScore;
    }

    private void Update()
    {
        score.GetComponent<Text>().text = m_currentScore.ToString();
    }
}
