using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserEyesUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    public LaserEyes LE;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = Mathf.Round(LE.getTimeTillCooldown()).ToString();
    }
}
