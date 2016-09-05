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
        checkpoint = new Vector3(playerTransform.position.x, playerTransform.position.y);
    }

    void RespawnToLastCheckpoint()
    {
        playerTransform.position = new Vector3(checkpoint.x, checkpoint.y);
    }
}
