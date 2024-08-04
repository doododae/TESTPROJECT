using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Killzone Start called on: " + gameObject.name);
    }

    private void Awake()
    {
        Debug.Log("Killzone Awake called on: " + gameObject.name);
        
        // Check if the necessary components are present
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogError("Killzone is missing a Collider2D component!");
        }
        else if (!GetComponent<Collider2D>().isTrigger)
        {
            Debug.LogWarning("Killzone's Collider2D is not set as a trigger!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
    Debug.Log("Trigger entered by: " + collision.gameObject.name);
    if (collision.CompareTag("Player"))
    {
        Debug.Log("Player entered killzone");
        KillPlayer(collision.gameObject);
    }
    }

    private void KillPlayer(GameObject player)
    {
        Debug.Log("Killing player");
        player.SetActive(false);
        Invoke("RespawnPlayer", 1f);
    }

    private void RespawnPlayer()
    {
        if (RespawnManager.Instance == null)
        {
            Debug.LogError("RespawnManager instance is null!");
            return;
        }
        Debug.Log("Attempting to respawn player");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = RespawnManager.Instance.GetRespawnPosition();
            player.SetActive(true);

            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}