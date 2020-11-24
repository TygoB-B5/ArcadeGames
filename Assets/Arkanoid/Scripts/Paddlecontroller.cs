using System.Collections;
using UnityEngine;

public class Paddlecontroller : MonoBehaviour
{
    private float x = 0;
    void Update()
    {
        x = GetMouseXValue() * Time.deltaTime * 10;
        x = Mathf.Clamp(x, -8, 8);

        //bot player
#if false
        transform.position = new Vector3(FindObjectOfType<Ball>().transform.position.x, transform.position.y);
#else
        transform.position += new Vector3(x, 0, 0);
#endif
    }

    float GetMouseXValue()
    {
        float mouseX = Input.GetAxisRaw("Horizontal");
        return mouseX;
    }

    public void EnablePowerupMethod()
    {
        StartCoroutine(EnablePowerup());
    }

    IEnumerator EnablePowerup()
    {
        transform.localScale = new Vector3(transform.localScale.x + 4, transform.localScale.y, transform.localScale.z);
        yield return new WaitForSeconds(7.5f);
        transform.localScale = new Vector3(transform.localScale.x - 4, transform.localScale.y, transform.localScale.z);
        yield return null;
    }
}
