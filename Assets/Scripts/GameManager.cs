using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverUI;
    public GameObject player;
    public Transform respawnPoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        if (player != null && respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;
            player.SetActive(true);
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            Debug.LogError("Player or respawn point not set in GameManager");
        }
    }

    public void quitGame()
    {
        Debug.Log("Game closed.");
        Application.Quit();
    }
}