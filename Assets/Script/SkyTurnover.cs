using UnityEngine;
using System.Collections;

public class SkyTurnover : MonoBehaviour {

    public Material[] materials;
    MeshRenderer myRenderer;

    int materialIndex = 0;

    void OnEnable()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material = materials[0];
        EventManager.StartListening("change", ChangeSkyTexture);
    }
	
	void ChangeSkyTexture()
    {
        materialIndex++;
        if (materialIndex >= materials.Length)
            materialIndex = 0;

        myRenderer.material = materials[materialIndex];
	}
}
