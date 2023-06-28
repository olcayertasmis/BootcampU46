using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandMiniMAp : MonoBehaviour
{
    private GameObject cam;
    public Camera mapCamera;
    public Toggle menuOn;
    public float big = 30.0f;
    //public Slider mapZoom;

    void Start()
    {
        cam = GameObject.Find("MapCamera");
        mapCamera = cam.GetComponent<Camera>();
        menuOn = gameObject.GetComponent<Toggle>();
    }

    public void Update()
    {
        if (menuOn.isOn)
        {
            mapCamera.orthographicSize = big;
            //mapCamera.orthographicSize = mapZoom.value;
        }
        else
        {
            mapCamera.orthographicSize = 15.0f;
        }
        //mapCamera.orthographicSize = mapZoom.value;
    }
}
