using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public Transform[] Spawnpoint;

    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Score;
    public GameObject ScoreText;


    public bool PlayerActive;
    public bool GameFinish;


    public int score = 0;

    [Header("Timer")]
    public float timeValue = 90;

    [Header("FinishGame")]

    public GameObject FinishPanelWin;
    public GameObject FinishPanelLoss;


    // Start is called before the first frame update
    void Awake()
    {
        Score.text = score.ToString();
        int randomSpawn = Random.Range(0, Spawnpoint.Length);
        Instantiate(Player, Spawnpoint[randomSpawn].position, Quaternion.identity);
        PlayerActive = true;
        FinishPanelWin.SetActive(false);
        FinishPanelLoss.SetActive(false);
        ScoreText.SetActive(false);
        Score.gameObject.SetActive(false);
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = score.ToString();
        if (!PlayerActive)
        {
            int randomSpawn = Random.Range(0, Spawnpoint.Length);
            Instantiate(Player, Spawnpoint[randomSpawn].position, Quaternion.identity);
            PlayerActive = true;
        }

        if (GameFinish)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            if(score > 0)
            {
                FinishPanelWin.SetActive(true);
                ScoreText.SetActive(true);
                Score.gameObject.SetActive(true);
            }
            if(score <= 0)
            {
                FinishPanelLoss.SetActive(true);
                ScoreText.SetActive(true);
                Score.gameObject.SetActive(true);
            }
        }

        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            GameFinish = true;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeDiplay)
    {
        if(timeDiplay < 0)
        {
            timeDiplay = 0;
        }

        if(timeDiplay <= 10)
        {
            Timer.color = Color.red;
        }

        float minutes = Mathf.FloorToInt(timeDiplay / 60);
        float secondes = Mathf.FloorToInt(timeDiplay % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, secondes);
    }

    public void ResterGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
