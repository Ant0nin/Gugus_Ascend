using UnityEngine;
using System.Collections;

public class SkyTurnover : MonoBehaviour {

    public Texture2D[] skies;

    int skyIndex = 0;
    Shader myShader;
    Material myMaterial;

    void OnStart()
    {
        myMaterial = GetComponent<Material>();
    }

	void OnEnable()
    {
        EventManager.StartListening("change", ChangeSkyTexture);
    }
	
	void ChangeSkyTexture()
    {
        skyIndex++;
        if (skyIndex >= skies.Length)
            skyIndex = 0;

        //myMaterial.SetTexture()
	}
}
