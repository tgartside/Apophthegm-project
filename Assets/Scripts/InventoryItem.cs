using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public SelectedInventoryItem SI_Item;
    public SelectedWorldItem SW_Item;
    public Item item;
    public TextBoxManager tb_Manager;

    [Header("UI")]
    public Image image;

    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        tb_Manager = GameObject.Find("TextBoxManager").GetComponent<TextBoxManager>();
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        tb_Manager = GameObject.Find("TextBoxManager").GetComponent<TextBoxManager>();

        SI_Item.item = item;
        if (PlayerPrefs.GetInt("usingItem") == 1)
        {
            SW_Item.worldItem.UseItem(this.transform.parent.gameObject);
        }
        else
        {
            tb_Manager.DisplayText(item.flavourText, item.textSource);
        }
    }

}
