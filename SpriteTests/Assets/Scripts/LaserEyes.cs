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

    public float timeTillCooldown = 3f;
    private float timeTillCooldownRESET;
    private bool onCooldown = false;

    public float getTimeTillCooldown() { return timeTillCooldown; }

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        spawnPos = GetComponent<Transform>();
        mainCam = Camera.main;

        timeTillCooldownRESET = timeTillCooldown;
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
        if (Input.GetButton("Fire1") && Time.timeScale != 0 && !onCooldown)
        {
            timeTillCooldown -= Time.deltaTime;

            if (timeTillCooldown <= 0)
                StartCoroutine(LaserCooldown(5f));

            Vector2 cursorPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

            if (!startedLaser && !onCooldown)
            {
                AudioManager.instance.Play("LaserEyes");
                lr.enabled = true;
                startedLaser = true;
            }

            if (activeEye)
            {
                RaycastHit2D hit = Physics2D.Raycast(cursorPosition, Vector2.zero);

                if (hit.collider != null && !onCooldown)
                {
                    if (hit.collider.gameObject.tag == "NPC")
                    {
                        Civilian civ = hit.collider.gameObject.GetComponent<Civilian>();
                        civ.KillCivilian();
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
            AudioManager.instance.Stop("Fire");
            startedLaser = false;
            lr.enabled = false;
        }
        if (!Input.GetButton("Fire1") && !onCooldown && timeTillCooldown < timeTillCooldownRESET)
        {
            timeTillCooldown += Time.deltaTime;
        }


    }

    void FlipLaserSO()
    {
        lr.sortingOrder = lr.sortingOrder == 51 ? 45 : 51;
    }

    private IEnumerator LaserCooldown(float time)
    {
        AudioManager.instance.Play("PowerDown");

        onCooldown = true;
        AudioManager.instance.Stop("LaserEyes");
        AudioManager.instance.Stop("Fire");
        lr.enabled = false;
        startedLaser = false;

        yield return new WaitForSeconds(time);

        onCooldown = false;
        AudioManager.instance.Play("LaserReady");
        timeTillCooldown = timeTillCooldownRESET;
    }
}
