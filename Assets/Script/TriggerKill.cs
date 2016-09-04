using UnityEngine;
using System.Collections;

public class TriggerKill : MonoBehaviour {

	void OnCollisionEnter2D()
    {
        EventManager.TriggerEvent("kill");
    }
}
