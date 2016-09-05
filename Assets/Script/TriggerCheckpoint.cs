using UnityEngine;
using System.Collections;

public class TriggerCheckpoint : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        EventManager.TriggerEvent("checkpoint");
        gameObject.SetActive(false);
    }
}
