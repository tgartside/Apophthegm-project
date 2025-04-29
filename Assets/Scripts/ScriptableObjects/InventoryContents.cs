using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryContents", menuName = "ScriptableObjects/InventoryContents")]
public class InventoryContents : ScriptableObject
{

    public Item[] content = new Item[6];

}
