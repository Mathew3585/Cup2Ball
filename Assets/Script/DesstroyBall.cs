using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class DesstroyBall : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.PlayerActive = false;
            gameManager.score--;
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, .1f);
            Destroy(collision.gameObject);
        }
    }
}
