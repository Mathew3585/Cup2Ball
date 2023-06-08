using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupManager : MonoBehaviour
{

    [SerializeField]
    private bool CupRed;

    [SerializeField]
    private bool CupBlue;

    [SerializeField]
    private bool CupGreen;

    private BallController ball;
    private GameManager gameManager;

    public GameObject ScorePoint;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        ScorePoint.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = collision.GetComponent<BallController>();
        if (collision.CompareTag("Player"))
        {
            if (CupRed && ball.Red)
            {
                gameManager.score++;
            }
            else if (CupBlue && ball.Bleu)
            {
                gameManager.score++;
            }
            else if (CupGreen && ball.Green)
            {
                gameManager.score++;
            }
            else
            {
                gameManager.score--;
            }
        }

        ScorePoint.SetActive(true);
        gameManager.PlayerActive = false;
        Destroy(collision.gameObject);
    }
}
