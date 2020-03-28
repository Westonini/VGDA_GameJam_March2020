using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructHitbox : MonoBehaviour
{
    public Structure structObject;

    public void CallTakeDamage()
    {
        structObject.TakeDamage();
    }
}
