﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    private float zoomLerpSpeed = 10;
    void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        targetZoom = targetZoom - scrollData * zoomFactor;
        if(targetZoom > 9)
        {
            targetZoom = 9;
        }
        else if(targetZoom < 3)
        {
            targetZoom = 3;

        }


        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);

    }
}
