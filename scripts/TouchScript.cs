using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchScript : MonoBehaviour {

    GameObject panel;
    GameObject textObject;
    GameObject handler;
    GameObject closest;
    Text text;

	// Use this for initialization
	void Start () {
        panel = GameObject.Find("AnnoPanel");
        textObject = GameObject.Find("AnnoText");
        text = textObject.GetComponent<Text>();
        handler = GameObject.Find("AnnotationHandler");
        panel.SetActive(false);
        textObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     TogglePanel();
        // }
    }

    public void TogglePanel()
    {
        if(panel.activeSelf)
        {
            panel.SetActive(false);
            textObject.SetActive(false);
        } else
        {
            closest = handler.GetComponent<AnnotationScript>().closestPoint;
            text.text = closest.GetComponent<TextScript>().Text;
            panel.SetActive(true);
            textObject.SetActive(true);
        }
    }
}
