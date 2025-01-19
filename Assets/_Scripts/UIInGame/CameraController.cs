using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
   /* public Slider slider;       
    public float minPosition = 0f;
    public float maxPosition;
    public Transform CameraMaxPosition;
    void Start()
    {
        SetValue();
    }

    private void SetValue()
    {
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        float width = ((float)16 / 9) / ((float)Screen.width / (float)Screen.height);
        maxPosition = CameraMaxPosition.position.x / width - (cameraWidth / 2);

        slider.minValue = minPosition;
        slider.maxValue = maxPosition;
        slider.value = transform.position.x;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = value;
        transform.position = newPosition;
    }*/
    public float dragSpeed = 1f;
    private Vector3 dragOrigin;
    public float minPosition = 0f;
    public float maxPosition ;
    public Transform CameraMaxPosition;

    private void Start()
    {
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        float width = ((float)16 / 9) / ((float)Screen.width / (float)Screen.height);
        maxPosition = CameraMaxPosition.position.x / width - (cameraWidth / 2);
    }
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(0))
        {
            
            Vector3 difference = (Input.mousePosition - dragOrigin) * dragSpeed * Time.deltaTime;

           
            Vector3 move = new Vector3(-difference.x, 0, 0);
            transform.Translate(move, Space.World);

           
            float clampedX = Mathf.Clamp(transform.position.x, minPosition, maxPosition);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

            
            dragOrigin = Input.mousePosition;
        }
#elif UNITY_IOS || UNITY_ANDROID
      if (Input.touchCount == 1)
    {
        Touch touch = Input.GetTouch(0);

        
        if (touch.phase == TouchPhase.Began)
        {
            
            dragOrigin = new Vector3(touch.position.x, touch.position.y, 0);
        }
        
        else if (touch.phase == TouchPhase.Moved)
        {
           
            Vector3 currentPosition = new Vector3(touch.position.x, touch.position.y, 0);
            Vector3 difference = (currentPosition - dragOrigin) * dragSpeed * Time.deltaTime;

           
            Vector3 move = new Vector3(-difference.x, 0, 0);
            transform.Translate(move, Space.World);

         
            float clampedX = Mathf.Clamp(transform.position.x, minPosition, maxPosition);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

          
            dragOrigin = currentPosition;
        }
    }
#endif
    }
}

