using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DartManager : MonoBehaviour
{
    [SerializeField] private Dart[] darts;
    [SerializeField] private ControllerManager controller;
    [SerializeField] private Button shootButton;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text dartsLeft;
    [SerializeField] private GameObject gameOver;
    
    private int score;
    private bool isGameOver;

    private void Start()
    {
        StartCoroutine(IsGameOver());
    }

    private void Update()
    {
        for (int i = darts.Length-1; i >= 0; i--)
        {
            if (!darts[i].IsNotUsed)
            {
                SetActiveDart(i);
                dartsLeft.text = $"Dart(s): {i}";
                break;
            }
        }
        
        if(isGameOver)
            gameOver.SetActive(true);
    }

    private IEnumerator IsGameOver()
    {
        // Wait until all darts are not used, then game over
        yield return new WaitUntil(delegate
        {
            if (Array.TrueForAll(darts, dart => dart.IsNotUsed))
            {
                isGameOver = true;
                return isGameOver;
            }

            return isGameOver;
        });
    }
    
    /// <summary>
    /// Set active next dart and add listener to shoot button
    /// </summary>
    /// <param name="index"></param>
    private void SetActiveDart(int index)
    {
        darts[index].gameObject.SetActive(true);
        controller.SetDart(darts[index]);
        
        shootButton.onClick.RemoveAllListeners();
        
        shootButton.onClick.AddListener(delegate
        {
            darts[index].Shoot();
        });
    }
    
    /// <summary>
    /// Add score by value
    /// </summary>
    /// <param name="value"></param>
    public void AddScore(int value)
    {
        // Add score
        score += value;
        scoreText.text = score.ToString();
    }
}
