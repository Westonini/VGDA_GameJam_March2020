using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompCheck : MonoBehaviour
{
    private Collider2D structCollider;

    private void Awake()
    {
        structCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StompHitbox")
        {
            StructHitbox detectedStruct = collision.gameObject.GetComponent<StructHitbox>();
            detectedStruct.CallTakeDamage();
            structCollider.enabled = false;
        }
    }
}
