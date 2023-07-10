using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private Player player;

    private int score = 0;

    private void Awake() {
        Application.targetFrameRate = 60;
        transform.position = Vector3.zero;

        Pause();
    }
    
    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        button.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver() {
        button.SetActive(true);
        Pause();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
