using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Narrative : MonoBehaviour
{
    List<GameObject> objects = new List<GameObject>();
    public GameObject placeholder;
    GameObject narrativeTextPanel;
    Text narrativeText;
    public GameObject prefab;
    string introText;
    string period;
    public int active;

    void Start()
    {
        active = -1;
        narrativeTextPanel = GameObject.FindWithTag("NarrativeTextPanel");
        narrativeText = (Text) GameObject.FindWithTag("NarrativeText").GetComponent<Text>();
    }

    void Update()
    {
        if(active < objects.Count && active != -1)
        {
            if(!objects[active].activeSelf)
            {
                foreach(GameObject obj in objects)
                {
                    obj.SetActive(false);
                }
                objects[active].SetActive(true);
                Debug.Log("Change active object" + objects[active].GetComponent<MuseumObject>().GetObjectName());
                Camera.main.transform.LookAt(objects[active].transform);
            }
        } else if(active == -1)
        {
            foreach(GameObject obj in objects)
            {
                obj.SetActive(false);
            }
        }
    }

    public void Init(string anIntroText, string aPeriod)
    {
        introText = anIntroText;
        period = aPeriod;
        narrativeText.text = introText;
        narrativeTextPanel.SetActive(true);
        active = 0;
        ChangeLinks();
    }

    public void AddObject(GameObject obj)
    {
        Debug.Log("Added object: " + obj.name);
        objects.Add(obj);
    }

    public List<GameObject> GetObjectList()
    {
        return objects;
    }

    public GameObject GetActiveObject()
    {
        if(objects.Count == 0 || active == -1)
        {
            return placeholder;
        }
        return objects[active];
    }

    public void NextObject()
    {
        if((active + 1) < objects.Count)
        {
            Debug.Log("Narrative:NextObject");
            ChangeObject(active + 1);
        }
    }

    public void PreviousObject()
    {
        if((active - 1) >= 0)
        {
            Debug.Log("Narrative:PreviousObject");
            ChangeObject(active - 1);
        }
    }

    public string GetPeriod()
    {
        return period;
    }

    public void ChangeObject(int i)
    {
        if(i > -1 && i < objects.Count)
        {
            active = i;
            Debug.Log("Narrative:ChangeObject");
            narrativeText.text = objects[active].GetComponent<MuseumObject>().GetSummary();
            narrativeTextPanel.SetActive(true);
            ChangeLinks();
        }
    }

    void ChangeLinks()
    {
        Debug.Log("ChangeLinks");
        GameObject panel = GameObject.FindWithTag("LinkPanel");
        List<Link> links = objects[active].GetComponent<MuseumObject>().GetLinks();
        DestroyLinks(panel);
        foreach(Link link in links)
        {
            GameObject linkButton = (Instantiate (prefab) as GameObject);
            linkButton.transform.SetParent(panel.transform);
            linkButton.GetComponent<LinkButtonScript>().Init(link.GetObjectId(), link.GetName(), link.GetLinkType());
        }
    }

    void DestroyLinks(GameObject panel)
    {
        foreach(Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
