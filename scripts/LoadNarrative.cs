using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LoadNarrative : MonoBehaviour
{
    GameObject narrObject;
    Narrative narr;
    // Use this for initialization
    void Start ()
    {
        narrObject = GameObject.FindWithTag("Narrative");
        ParseXML("Narrative1");
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public void ParseXML(string narrativeName)
    {
        TextAsset textAsset = (TextAsset) Resources.Load("Narratives/"+narrativeName);

        XDocument doc = XDocument.Parse(textAsset.text);

        XElement narrXml = doc.Element("Narrative");
        string introText = narrXml.Element("IntroText").Value;
        string period = narrXml.Element("IntroText").Value;

        narr = narrObject.GetComponent<Narrative>();

        foreach (XElement xe in narrXml.Descendants("Object"))
        {
            int id = Int32.Parse(xe.Attribute("id").Value);
            string name = xe.Element("Name").Value;
            string objFileName = xe.Element("FileName").Value;
            string summary = xe.Element("Summary").Value;
            string text = xe.Element("Text").Value;

            GameObject g = CreateObject(objFileName);

            g.AddComponent<MuseumObject>();
            g.GetComponent<MuseumObject>().Init(id, name, objFileName, summary, text);
            g.SetActive(false);

            foreach(XElement el in xe.Descendants("Link"))
            {
                Debug.Log(el.Element("ObjectId").Value);
                Debug.Log(el.Element("LinkType").Value);
                Link link = new Link(Int32.Parse(el.Element("ObjectId").Value), el.Element("ObjectName").Value, el.Element("LinkType").Value);
                g.GetComponent<MuseumObject>().AddLink(link);
            }

            narr.AddObject(g);
        }

        narr.Init(introText, period);
        Debug.Log("Narrative loaded");
    }

    private GameObject CreateObject(string objFileName)
    {
        GameObject g = GameObject.Instantiate( Resources.Load("MuseumModels/" + objFileName + "_Lres") ) as GameObject;
        Texture2D tex = (Texture2D)Resources.Load("MuseumTextures/" + objFileName + "_diffuse");
        g.GetComponentInChildren<Renderer>().material.mainTexture = tex;
        g.AddComponent<PinchZoom>();
        g.AddComponent<TouchRotate>();

        return g;
    }
}
