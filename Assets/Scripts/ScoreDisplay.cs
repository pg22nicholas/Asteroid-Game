using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI m_scoreText;

    void Start()
    {
        Score.OnScoreAdded -= SetScoreDisplay; // unsubscribe to make sure not subscribed previously
        Score.OnScoreAdded += SetScoreDisplay;
    }

    private void SetScoreDisplay(int score)
    {
        m_scoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        Score.OnScoreAdded -= SetScoreDisplay;
    }
}
