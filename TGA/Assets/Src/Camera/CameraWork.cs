using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    public Transform camTarget;
    public float ratio;

    private Vector2 camSize;

    void Start()
    {
        Vector2 cameraMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 cameraMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        camSize = cameraMax - cameraMin;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 startPos = camTarget.position;
        startPos.x += camSize.x * 0.5f;
        startPos.y = 0.0f;
        startPos.z = -10.0f;

        Vector3 ratioPos = startPos;
        ratioPos.x -= camSize.x * ratio;
        transform.position = ratioPos;
    }
}
