using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    public Characters characterList;
    private Characters.SpriteList chosenCharacter;

    private SpriteRenderer SR;
    private Collider2D col;
    public Collider2D wallCol;
    public Sprite[] bloodSprites;
    private bool civilianDead = false;

    public delegate void CivilianDeath();
    public static event CivilianDeath _civilianDeath;

    public bool getCivilianDead() { return civilianDead; }

    void Awake()
    {
        SR = GetComponentInChildren<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        int randomInt = Random.Range(0, characterList.playerCharacters.Length);

        chosenCharacter = characterList.playerCharacters[randomInt];
        SR.sprite = chosenCharacter.front;
    }

    public void KillCivilian()
    {
        civilianDead = true;

        //Disable collider
        col.enabled = false;
        wallCol.enabled = false;

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
