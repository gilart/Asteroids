using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Camera MainCamera;
    public Vector2 screenBounds;

    void Start()
    {
        MainCamera = Camera.main;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));        
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        if(viewPos.x < screenBounds.x)//left side
        {
            viewPos.x += 2 * -screenBounds.x; 
        }

        if (viewPos.x > -screenBounds.x)//right side
        {
            viewPos.x += 2 * screenBounds.x;
        }

        if (viewPos.y < screenBounds.y)//bottom side
        {
            viewPos.y += 2 * -screenBounds.y;
        }

        if (viewPos.y > -screenBounds.y)//top side
        {
            viewPos.y += 2 * screenBounds.y;
        }

        transform.position = viewPos;
    }
}
