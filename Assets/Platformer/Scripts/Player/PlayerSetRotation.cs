using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetRotation : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.rotation = Quaternion.Euler(0, collision.transform.eulerAngles.y + 90, 0);
        }
    }
}
