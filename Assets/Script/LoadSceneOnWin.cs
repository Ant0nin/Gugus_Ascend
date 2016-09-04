using UnityEngine;
using System.Collections;

public class LoadSceneOnWin : MonoBehaviour {

	void OnEnable()
    {
        EventManager.StartListening("win", GoToWinScene);
    }
	
	void GoToWinScene() {

        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        Application.LoadLevel("win");
        yield return new WaitForSeconds(5);
    }
}
