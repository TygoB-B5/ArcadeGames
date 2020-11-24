using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public float HorizontalLook { get; private set; }
    public float VerticalLook { get; private set; }
    public bool FireWeapons { get; private set; }
    public bool Sprint { get; private set; }
    public bool JumpDown { get; private set; }
    public bool Jump { get; private set; }
    public bool LeftMouse { get; private set; }
    public bool RightMouse { get; private set; }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        HorizontalLook = Input.GetAxis("Mouse X");
        VerticalLook = Input.GetAxis("Mouse Y");
        FireWeapons = Input.GetButtonDown("Fire1");
        Sprint = Input.GetKey(KeyCode.LeftShift);
        JumpDown = Input.GetKeyDown(KeyCode.Space);
        Jump = Input.GetKey(KeyCode.Space);
        LeftMouse = Input.GetMouseButtonDown(0);
        RightMouse = Input.GetMouseButtonDown(1);
    }
}
