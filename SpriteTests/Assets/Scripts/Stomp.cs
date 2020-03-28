using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    public Collider2D structCheck;

    void OnEnable()
    {
        PlayerListener._playerJumping += HandleEnableCheck;
    }

    void OnDisable()
    {
        PlayerListener._playerJumping -= HandleEnableCheck;
    }

    private void HandleEnableCheck()
    {
        StartCoroutine(EnableCheck((20f / 60f), 0.35f));
    }

    private IEnumerator EnableCheck(float startTime, float endTime)
    {
        yield return new WaitForSeconds(startTime);
        structCheck.enabled = true;
        yield return new WaitForSeconds(endTime);
        structCheck.enabled = false;
    }
}
