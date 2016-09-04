using UnityEngine;
using System.Collections;

public class TriggerWinLevel : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            EventManager.TriggerEvent("win");
    }
}
