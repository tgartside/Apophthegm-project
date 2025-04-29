using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    //public string itemName;
    public Sprite image;
    public string flavourText;
    public string textSource;

}
