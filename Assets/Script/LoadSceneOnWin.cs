using UnityEngine;
using System.Collections;

public class LoadSceneOnWin : MonoBehaviour {

	void OnEnable()
    {
        EventManager.StartListening("win", GoToWinScene);
    }
	
	void GoToWinScene() {
        Application.LoadLevel("win");
    }
}
