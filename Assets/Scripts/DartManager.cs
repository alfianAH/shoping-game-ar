using UnityEngine;
using UnityEngine.UI;

public class DartManager : MonoBehaviour
{
    [SerializeField] private Dart[] darts;
    [SerializeField] private ControllerManager controller;
    [SerializeField] private Button shootButton;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text dartsLeft;
    private int score;
    
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
    }

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

    public void AddScore(int value)
    {
        // Add score
        score += value;
        scoreText.text = score.ToString();
    }
}
