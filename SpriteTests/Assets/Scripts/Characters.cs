using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    [System.Serializable]
    public class SpriteList
    {
        public string characterName;
        public int skinVariant;
        public Sprite front;
        public Sprite frontItem;
        public Sprite back;
        public Sprite backItem;
    }

    public SpriteList[] playerCharacters;
}
