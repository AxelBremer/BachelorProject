using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : MonoBehaviour {
    public string modelName;

	// Use this for initialization
	void Start () {
        Debug.Log(modelName);
        GameObject g = GameObject.Instantiate( Resources.Load("MuseumModels/" + modelName) ) as GameObject;
        Debug.Log(modelName);
        Texture tex = (Texture)Resources.Load("MuseumTextures/" + modelName + "-diffuse");
        Texture norm = (Texture)Resources.Load("MusuemTextures/" + modelName + "-normal");
        g.GetComponentInChildren<Renderer>().material.shaderKeywords = new string[1]{"_NORMALMAP"};
        g.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", tex);
        g.GetComponentInChildren<Renderer>().material.SetTexture("_BumpMap", norm);
	}

}
