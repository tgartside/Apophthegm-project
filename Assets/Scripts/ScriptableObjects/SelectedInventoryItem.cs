using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedInventoryItem", menuName = "ScriptableObjects/SelectedInventoryItem")]
public class SelectedInventoryItem : ScriptableObject
{
    public Item item;
}
