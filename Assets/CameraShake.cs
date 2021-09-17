using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration;
    public float magnitude;
    public bool isShake;

    private void Update()
    {
        if (isShake)
        {
            Vector3 originalPos = transform.position;

            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.position = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;
            }

            transform.position = originalPos;
            //isShake = false;
        }
    }
}
