using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    private LineRenderer lr;
    private Transform spawnPos;
    private bool startedLaser;

    public bool activeEye;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        spawnPos = GetComponent<Transform>();
    }

    void OnEnable()
    {
        PlayerListener._playerFlippedVert += FlipLaserSO;
    }

    void OnDisable()
    {
        PlayerListener._playerFlippedVert -= FlipLaserSO;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!startedLaser)
            {
                AudioManager.instance.Play("LaserEyes");
                lr.enabled = true;
                startedLaser = true;
            }

            lr.SetPosition(0, spawnPos.position);
            Vector2 CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(1, CursorPosition);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            AudioManager.instance.Stop("LaserEyes");
            startedLaser = false;
            lr.enabled = false;
        }

        if (activeEye)
        {
            RaycastHit hit;
            if (Physics.Raycast(spawnPos.position, spawnPos.forward, out hit))
            {
                if (hit.collider.gameObject.tag == "NPC")
                {
                    Debug.Log("hit civilian");
                }
            }
        }
    }

    void FlipLaserSO()
    {
        lr.sortingOrder = lr.sortingOrder == 51 ? 45 : 51;
    }
}
