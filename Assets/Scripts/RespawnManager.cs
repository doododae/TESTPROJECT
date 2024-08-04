using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;
    private Transform respawnPoint;

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

    private void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint").transform;
    }

    public Vector3 GetRespawnPosition()
    {
        return respawnPoint != null ? respawnPoint.position : Vector3.zero;
    }
}