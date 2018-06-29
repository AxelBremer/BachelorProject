using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MuseumObject : MonoBehaviour
{
    int id;
    string objectName;
    string fileName;
    string modelName;
    string textureName;
    string summary;
    string text;
    List<Link> links = new List<Link>();
    public float scale = 0f;

    public void Init(int anId, string aName, string aFileName, string aSummary, string aText)
    {
        id = anId;
        objectName = aName;
        fileName = aFileName;
        summary = aSummary;
        text = aText;
        modelName = "MuseumModels/" + fileName + "_Lres";
        textureName = "MuseumTextures/" + fileName + "_diffuse";
    }

    void Update()
    {
        transform.localScale += new Vector3(scale, scale, scale);
    }

    public string GetModelName()
    {
        return modelName;
    }

    public string GetTextureName()
    {
        return textureName;
    }

    public int GetId()
    {
        return id;
    }

    public string GetObjectName()
    {
        return objectName;
    }

    public string GetSummary()
    {
        return summary;
    }

    public string GetText()
    {
        return text;
    }

    public List<Link> GetLinks()
    {
        return links;
    }

    public void AddLink(Link l)
    {
        links.Add(l);
        Debug.Log(objectName + " added link " + l.GetName());
    }
}
