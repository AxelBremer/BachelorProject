using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnotationScript : MonoBehaviour {

    GameObject[] points;
    public GameObject closestPoint;
    GameObject cam, panel;
    Text text;

    // Use this for initialization
    void Start () {
        points = GameObject.FindGameObjectsWithTag("Annotation");
        cam = GameObject.Find("ARCamera");
    }

	// Update is called once per frame
	void Update () {
        int closest = -1;
        float minDist = Mathf.Infinity;
		for(int i = 0; i < points.Length; i++)
        {
            float d = Vector3.Distance(cam.transform.position, points[i].transform.position);
            if(d < minDist)
            {
                closest = i;
                minDist = d;
            }
        }
        for (int i = 0; i < points.Length; i++)
        {
            if(i == closest)
            {
                Behaviour halo = (Behaviour)points[i].GetComponent("Halo");
                halo.enabled = true;
                closestPoint = points[i];
            } else
            {
                Behaviour halo = (Behaviour)points[i].GetComponent("Halo");
                halo.enabled = false;
            }
        }
    }
}
