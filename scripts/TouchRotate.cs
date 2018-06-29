using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour {
    Vector2 currentPosition = Vector2.zero;
    Vector2 lastPosition = Vector2.zero;
    Vector2 deltaPosition = Vector2.zero;
    public float rotateSpeed = 0.5f;
    public int axis = 1;

    // Update is called once per frame
    void Update () {
        checkTouch();
        checkMouse();
    }

    void checkTouch()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if(axis == 1)
            {
                transform.Rotate(0,-touch.deltaPosition.x*rotateSpeed,0);
            } else
            {
                transform.Rotate(touch.deltaPosition.y*rotateSpeed,0,0);
            }
        }
    }

    void checkMouse()
    {
        if(Input.GetButton("Fire1"))
        {
            if(currentPosition != Vector2.zero) lastPosition = currentPosition;
            currentPosition = Input.mousePosition;
            if(lastPosition != Vector2.zero) deltaPosition = currentPosition - lastPosition;
            if(axis == 1)
            {
                transform.Rotate(0,-deltaPosition.x*rotateSpeed,0);
            } else
            {
                transform.Rotate(deltaPosition.y*rotateSpeed,0,0);
            }

        }

        if(Input.GetButtonUp("Fire1"))
        {
            currentPosition = Vector2.zero;
            lastPosition = Vector2.zero;
            deltaPosition = Vector2.zero;
        }
    }
}
