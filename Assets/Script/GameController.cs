using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    public double spawnTime;

    double p_spawnTime;
    bool gameOver = false;
    int score;
    UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.txtScore.text = "Score: 0";
        p_spawnTime=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameObject[] objs = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in objs)
            {
                if (obj.tag.Equals("Obstacle"))
                {
                    Destroy(obj);
                }
            }
            player.SetActive(false);
            uiManager.ShowGameOverPanel(true);
            p_spawnTime = 0;
            return;
        }
        p_spawnTime -= Time.deltaTime;
        if (p_spawnTime <= 0)
        {
            SpawnObstacle();
            p_spawnTime = spawnTime;
        }
    }

    public void Replay()
    {
        gameOver = false;
        uiManager.txtScore.text = "Score: 0";
        player.SetActive(true);
        uiManager.ShowGameOverPanel(false);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void SpawnObstacle()
    {
        if (obstacle)
        {
            float randYPos = Random.Range(-4f, -2f);
            Vector2 spawnPos = new Vector2(10, randYPos);
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    public double GetP_spawnTIme()
    {
        return p_spawnTime;
    }

    public void SetP_spawnTime(double value)
    {
        p_spawnTime = value;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void SetGameOver(bool value)
    {
        gameOver = value;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int value)
    {
        score = value;
    }
    
}
