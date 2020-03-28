using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    private SpriteRenderer SR;
    public int health = 2;
    private float darkenAmount;
    public GameObject explosionPrefab;

    public GameObject shadow;
    public GameObject walkway;
    public GameObject colliders;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

        darkenAmount = 100f / (health * 100f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            TakeDamage();
    }

    public void TakeDamage()
    {
        health--;
        SR.color += new Color(-darkenAmount, -darkenAmount, -darkenAmount);

        if (health <= 0)
        {
            DestroyStructure();
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

        SR.sprite = null;
    }
}
