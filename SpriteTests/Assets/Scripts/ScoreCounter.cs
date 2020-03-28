using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static int structuresDestroyed;
    public static int peopleKilled;

    public static int structuresDestroyedHighest;
    public static int peopleKilledHighest;

    public TextMeshProUGUI structDestText;
    public TextMeshProUGUI peopleKilledText;

    public TextMeshProUGUI structDestTextHighest;
    public TextMeshProUGUI peopleKilledTextHighest;

    private void OnEnable()
    {
        Civilian._civilianDeath += IncPeopleKilledCount;
        Structure._structureDestroyed += IncStructDestroyedCount;
    }

    private void OnDisable()
    {
        Civilian._civilianDeath -= IncPeopleKilledCount;
        Structure._structureDestroyed -= IncStructDestroyedCount;
    }

    void Start()
    {
        structuresDestroyed = 0;
        peopleKilled = 0;

        UpdateCountText();
    }

    public void IncStructDestroyedCount()
    {
        structuresDestroyed++;

        if (structuresDestroyed > structuresDestroyedHighest)
            structuresDestroyedHighest = structuresDestroyed;

        UpdateCountText();
    }
    public void IncPeopleKilledCount()
    {
        peopleKilled++;

        if (peopleKilled > peopleKilledHighest)
            peopleKilledHighest = peopleKilled;

        UpdateCountText();
    }

    void UpdateCountText()
    {
        structDestText.text = structuresDestroyed.ToString();
        peopleKilledText.text = peopleKilled.ToString();

        structDestTextHighest.text = structuresDestroyedHighest.ToString();
        peopleKilledTextHighest.text = peopleKilledHighest.ToString();
    }
}
