using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform playerTransform;

    Vector3 checkpoint;
	
    void OnEnable()
    {
        EventManager.StartListening("kill", RespawnToLastCheckpoint);
        EventManager.StartListening("checkpoint", SaveCheckpoint);
        SaveCheckpoint();
    }

    void SaveCheckpoint()
    {
        checkpoint = playerTransform.position;
    }

    void RespawnToLastCheckpoint()
    {
        playerTransform.position = checkpoint;
    }
}
