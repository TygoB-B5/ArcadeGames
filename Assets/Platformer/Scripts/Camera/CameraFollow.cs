using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    private Camera cam;
    private float defaultFov;
    
    [SerializeField] private float smoothTime;
    [SerializeField] private float fovMultiplier;

    public Transform trackObject;
    public Vector3 offset { get; private set; }

    private void Awake()
    {
        cam = GetComponent<Camera>();
        defaultFov = cam.fieldOfView;
        SetOffset();
    }
    void Update()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, trackObject.transform.position - offset, smoothTime * Time.deltaTime);
        cam.fieldOfView = defaultFov + (Vector3.Distance(cam.transform.position, trackObject.transform.position - offset)) * fovMultiplier;
    }

    public void SetOffset()
    {
        offset = trackObject.transform.position - cam.transform.position;
    }
}
