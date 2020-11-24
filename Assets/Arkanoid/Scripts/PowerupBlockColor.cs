using System.Collections;
using UnityEngine;

public class PowerupBlockColor : MonoBehaviour
{
    private SpriteRenderer spriteRen;

    void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, 0.5f, 1);
        yield return new WaitForSeconds(0.1f);
        spriteRen.color = new Color(spriteRen.color.r, spriteRen.color.g, 0.75f, 1);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Flicker());
        yield return null;
    }
}
