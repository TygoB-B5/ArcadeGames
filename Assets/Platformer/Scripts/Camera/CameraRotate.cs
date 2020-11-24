using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{
    private Camera cam;
    private PlayerInput playerInput;
    private PlayerEngine playerEngine;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        playerInput = FindObjectOfType<PlayerInput>();
        playerEngine = FindObjectOfType<PlayerEngine>();
    }

    void Update()
    {
        if (playerInput.LeftMouse)
        {
            RotateCamera(45);
        } else if(playerInput.RightMouse)
        {
            RotateCamera(-45);
        }
    }

    private void RotateCamera(int rot)
    {
        GameObject posReference = CreateReferencePoint();
        cam.transform.position = FindObjectOfType<CameraFollow>().trackObject.position - FindObjectOfType<CameraFollow>().offset;
        RotateOnPivotPoint(posReference, rot);
        FindObjectOfType<CameraFollow>().SetOffset();
        Destroy(posReference);
    }

    private GameObject CreateReferencePoint()
    {
        GameObject referencePoint = new GameObject("ReferencePoint");
        referencePoint.transform.position = playerEngine.transform.position;
        Instantiate(referencePoint, playerEngine.transform.position, Quaternion.Euler(0, 0, 0));
        return referencePoint;
    }

    private void RotateOnPivotPoint(GameObject posReference, int rot)
    {
        transform.parent = posReference.transform;
        posReference.transform.Rotate(new Vector3(0, rot, 0));
        transform.parent = null;
    }


}
