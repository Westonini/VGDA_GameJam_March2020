using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int structuresDestroyed;
    public static int peopleKilled;

    void Start()
    {
        structuresDestroyed = 0;
        peopleKilled = 0;
    }
}
