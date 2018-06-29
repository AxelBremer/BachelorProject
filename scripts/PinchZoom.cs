using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour {

    public float zoomSpeed = .0005f;

    void Update()
    {
        Zoom();
    }

    void Zoom()
    {
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = touchDeltaMag - prevTouchDeltaMag;

            transform.localScale += Vector3.one * deltaMagnitudediff * zoomSpeed;
            transform.localScale = Vector3.Max(transform.localScale, new Vector3 (0.0001f,0.0001f,0.0001f));
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            transform.localScale += Vector3.one * zoomSpeed;
            transform.localScale = Vector3.Max(transform.localScale, new Vector3 (0.0001f,0.0001f,0.0001f));
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // forward
        {
            transform.localScale += Vector3.one * -zoomSpeed;
            transform.localScale = Vector3.Max(transform.localScale, new Vector3 (0.0001f,0.0001f,0.0001f));
        }
    }
}
