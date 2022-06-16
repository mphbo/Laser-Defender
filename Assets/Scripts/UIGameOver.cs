using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        // Debug.Log(scoreKeeper);
        scoreText.text = $"You Scored:\n{scoreKeeper.GetScore()}";
    }
}
