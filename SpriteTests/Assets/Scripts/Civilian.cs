using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    private SpriteRenderer SR;
    private Collider2D col;
    public Sprite[] bloodSprites;

    public delegate void CivilianDeath();
    public static event CivilianDeath _civilianDeath;

    void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void KillCivilian()
    {
        //Disable collider
        col.enabled = false;

        //Change sprite to a random bloody one
        int randomNum = Random.Range(0, bloodSprites.Length);
        SR.sprite = bloodSprites[randomNum];

        //Random death sound
        randomNum = Random.Range(1, 3);
        if (randomNum == 1)
            AudioManager.instance.PlayOneShot("Bloody1");
        else
            AudioManager.instance.PlayOneShot("Bloody2");

        if (_civilianDeath != null)
            _civilianDeath();

        //Kill object after 30 sec
        StartCoroutine(DestroySelf(30f));
    }

    private IEnumerator DestroySelf(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            KillCivilian();
    }
}
