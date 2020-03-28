using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float time;

    void Start()
    {
        StartCoroutine(DestroySelfAtTime(time));
    }

    private IEnumerator DestroySelfAtTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
