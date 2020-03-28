using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEyes : MonoBehaviour
{
    private LineRenderer lr;
    private Transform spawnPos;
    private bool startedLaser;

    public bool activeEye;

    private Camera mainCam;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        spawnPos = GetComponent<Transform>();
        mainCam = Camera.main;
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




        if (Input.GetButton("Fire1") && Time.timeScale != 0)
        {
            Vector2 cursorPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

            if (!startedLaser)
            {
                AudioManager.instance.Play("LaserEyes");
                lr.enabled = true;
                startedLaser = true;
            }

            if (activeEye)
            {
                RaycastHit2D hit = Physics2D.Raycast(cursorPosition, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "NPC")
                    {
                        Civilian civ = hit.collider.gameObject.GetComponent<Civilian>();
                        civ.KillCivilian();
                        AudioManager.instance.Play("Fire");
                    }
                    if (hit.collider.gameObject.tag == "LaserHitbox")
                    {
                        StructHitbox structObj = hit.collider.gameObject.GetComponent<StructHitbox>();
                        structObj.CallTakeDamage();
                        AudioManager.instance.Play("Fire");
                    }                
                }
                else
                    AudioManager.instance.Stop("Fire");
            }

                lr.SetPosition(0, spawnPos.position);

                lr.SetPosition(1, cursorPosition);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            AudioManager.instance.Stop("LaserEyes");
            startedLaser = false;
            lr.enabled = false;
        }


    }

    void FlipLaserSO()
    {
        lr.sortingOrder = lr.sortingOrder == 51 ? 45 : 51;
    }
}
