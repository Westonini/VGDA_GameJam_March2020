using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianMovement : MonoBehaviour
{
    public GameObject player;
    private float moveSpd = 0.5f;
    private bool playerWithinRange = false;
    private Civilian civ;

    public Animator anim;

    public void setPlayerWithinRange(bool truefalse) {playerWithinRange = truefalse;}

    private void Awake()
    {
        civ = GetComponent<Civilian>();
    }

    void Start()
    {
        moveSpd = Random.Range(0.4f, 0.7f);
    }

    void Update()
    {
        if (playerWithinRange && !civ.getCivilianDead())
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -1 * moveSpd * Time.deltaTime);
            anim.SetBool("Walking", true);
        }
        else
        {            
            anim.SetBool("Walking", false);
        }

    }
}
