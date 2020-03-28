using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    private SpriteRenderer SR;
    private int health;
    private float darkenAmount;
    public GameObject explosionPrefab;

    public GameObject shadow;
    public GameObject walkway;
    public GameObject colliders;
    public GameObject stompHitbox;
    public GameObject laserHitbox;

    public delegate void StructureDestroyed();
    public static event StructureDestroyed _structureDestroyed;

    private bool invulernable;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

        int randomNum = Random.Range(2, 5);
        health = randomNum;

        darkenAmount = 100f / (health * 100f);
    }

    public void TakeDamage()
    {
        if (!invulernable)
        {
            health--;
            SR.color += new Color(-darkenAmount, -darkenAmount, -darkenAmount);

            if (health <= 0)
            {
                DestroyStructure();
            }

            StartCoroutine(Invulnerability(20f / 60f));
        }

    }

    private void DestroyStructure()
    {
        //Explosion
        GameObject instantiatedExplosion;
        instantiatedExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation) as GameObject;
        //Explosion Sound
        int randomNum = Random.Range(1, 3);

        if (randomNum == 1)
            AudioManager.instance.PlayOneShot("Explosion1");
        else
            AudioManager.instance.PlayOneShot("Explosion2");

        //Disable sprites & colliders
        shadow.SetActive(false);
        walkway.SetActive(false);
        colliders.SetActive(false);
        stompHitbox.SetActive(false);
        laserHitbox.SetActive(false);

        SR.sprite = null;

        if (_structureDestroyed != null)
            _structureDestroyed();
    }

    private IEnumerator Invulnerability(float time)
    {
        invulernable = true;
        yield return new WaitForSeconds(time);
        invulernable = false;
    }
}
