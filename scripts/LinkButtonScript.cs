using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkButtonScript : MonoBehaviour {
    int objectId;
    string objectName;
    string linkType;
    Narrative narr;

    void Start()
    {
        narr = GameObject.FindWithTag("Narrative").GetComponent<Narrative>();
    }

    public void Init(int anId, string anObjectName, string aLinkType)
    {
        objectId = anId;
        objectName = anObjectName;
        linkType = aLinkType;
        Debug.Log("LinkButtonScript:Init " + objectName);
        GameObject t = transform.GetChild(0).gameObject;
        t.GetComponent<Text>().text = objectName;
        t = transform.GetChild(1).gameObject;
        t.GetComponent<Text>().text = linkType;
    }

    public void ActivateLink()
    {
        Debug.Log("LinkButtonScript:activateLink" + objectName);
        narr.ChangeObject(objectId);
    }
}
