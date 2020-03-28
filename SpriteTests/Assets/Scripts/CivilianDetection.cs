using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianDetection : MonoBehaviour
{
    private CivilianMovement CM;

    private void Awake()
    {
        CM = gameObject.GetComponentInParent<CivilianMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CM.setPlayerWithinRange(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CM.setPlayerWithinRange(false);
        }
    }
}
