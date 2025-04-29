using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;

public class WorldItem : MonoBehaviour, IPointerClickHandler
{

    public InventoryManager inventoryManager;
    public GameObject self;
    public string textToDisplay;
    public string sourceToDisplay;
    public TextBoxManager textBoxManager;
    public GameObject textBox;
    public GameObject inventoryScreen;
    public GameObject objectToActivate;
    public GameObject[] objs;
    public string connectedScene;
    public Vector2 playerPosition;
    public Sprite rippedPaintingSprite;
    public Sprite BRBPressed;

    [Header("Scriptable Objects")]
    public Item item;
    public BooleanValue bookPickedUp;
    public BooleanValue keyPickedUp;
    public BooleanValue pinPickedUp;
    public BooleanValue penPickedUp;
    public BooleanValue book2PickedUp;
    public BooleanValue drawerOpen;
    public BooleanValue R1DoorOpen;
    public BooleanValue bookcaseOpen;
    public BooleanValue paintingRipped;
    public BooleanValue deathButtonPressed;
    public BooleanValue finalNoteRead;
    public SelectedWorldItem SW_item;
    public SelectedInventoryItem SI_item;
    public InventoryContents i_contents;
    public VectorValue playerStorage;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.CompareTag("Item"))
        {
            textBoxManager.DisplayText(textToDisplay, sourceToDisplay);
            inventoryManager.AddItem(item);
            self.SetActive(false);
            if (this.name.Equals("Book"))
            {
                bookPickedUp.value = true;
            }
            else if (this.name.Equals("Key"))
            {
                keyPickedUp.value = true;
            }
            else if (this.name.Equals("Pin"))
            {
                pinPickedUp.value = true;
            }
            else if (this.name.Equals("Pen"))
            {
                penPickedUp.value = true;
            }
            else if (this.name.Equals("Book2"))
            {
                book2PickedUp.value = true;
            }
        }
        
        else if (this.CompareTag("ClickForText"))
        {
            if (this.name.Equals("BigRedButton"))
            {
                deathButtonPressed.value = true;
                this.GetComponent<SpriteRenderer>().sprite = BRBPressed;
                textBoxManager.DisplayText(textToDisplay, sourceToDisplay);

            }

            else if(this.name.Equals("FinalNote"))
            {
                finalNoteRead.value = true;
                textBoxManager.DisplayText(textToDisplay, sourceToDisplay);
            }

            else
            {
                textBoxManager.DisplayText(textToDisplay, sourceToDisplay);
            }
        }

        else if (this.CompareTag("InputItem"))
        {
            PlayerPrefs.SetInt("usingItem", 1);

            objs = GameObject.FindGameObjectsWithTag("Button");
            foreach(GameObject button in objs)
            {
                button.GetComponent<Button>().interactable = false;
            }
            SW_item.worldItem = this;
            inventoryScreen.SetActive(true);

            if (this.name.Equals("Painting"))
            {
                textBoxManager.DisplayText(textToDisplay, sourceToDisplay);
            }

            Time.timeScale = 0f;
        }

        else if (this.CompareTag("SceneChanger"))
        {
            SceneManager.LoadScene(connectedScene);
        }
    }

    public void UseItem(GameObject slot)
    {
        if (this.name.Equals("Scale"))
        {
            if (SI_item.item.name.Equals("BookAndQuill"))
            {
                Time.timeScale = 1.0f;
                inventoryScreen.SetActive(false);
                objectToActivate.SetActive(true);
                drawerOpen.value = true;

                PlayerPrefs.SetInt("usingItem", 0);

                objs = GameObject.FindGameObjectsWithTag("Button");
                foreach (GameObject button in objs)
                {
                    button.GetComponent<Button>().interactable = true;
                }


                i_contents.content[slot.GetComponent<InventorySlot>().slotID] = null;

                for (var i = slot.transform.childCount - 1; i >= 0; i--)
                {
                    Object.Destroy(slot.transform.GetChild(i).gameObject);
                }

            }
            else
            {
                Debug.Log("Wrong Item");
            }
        }

        else if (this.name.Equals("Door"))
        {
            if (SI_item.item.name.Equals("Key"))
            {
                Time.timeScale = 1.0f;
                inventoryScreen.SetActive(false);
                R1DoorOpen.value = true;

                PlayerPrefs.SetInt("usingItem", 0);

                objs = GameObject.FindGameObjectsWithTag("Button");
                foreach (GameObject button in objs)
                {
                    button.GetComponent<Button>().interactable = true;
                }

                i_contents.content[slot.GetComponent<InventorySlot>().slotID] = null;

                for (var i = slot.transform.childCount - 1; i >= 0; i--)
                {
                    Object.Destroy(slot.transform.GetChild(i).gameObject);
                }

                playerStorage.initialValue = playerPosition;
                SceneManager.LoadScene(connectedScene);

            }

            else
            {
                Debug.Log("Wrong Item");
            }
        }

        else if (this.name.Equals("Bookcase"))
        {
            if (SI_item.item.name.Equals("Book"))
            {
                Time.timeScale = 1.0f;
                inventoryScreen.SetActive(false);
                bookcaseOpen.value = true;

                PlayerPrefs.SetInt("usingItem", 0);

                objs = GameObject.FindGameObjectsWithTag("Button");
                foreach (GameObject button in objs)
                {
                    button.GetComponent<Button>().interactable = true;
                }

                i_contents.content[slot.GetComponent<InventorySlot>().slotID] = null;

                for (var i = slot.transform.childCount - 1; i >= 0; i--)
                {
                    Object.Destroy(slot.transform.GetChild(i).gameObject);
                }

                playerStorage.initialValue = playerPosition;
                SceneManager.LoadScene(connectedScene);
            }

            else
            {
                Debug.Log("Wrong Item");
            }
        }

        else if (this.name.Equals("Painting"))
        {
            if (SI_item.item.name.Equals("Pen"))
            {
                Time.timeScale = 1.0f;
                inventoryScreen.SetActive(false);
                this.GetComponent<SpriteRenderer>().sprite = rippedPaintingSprite;
                objectToActivate.SetActive(true);
                paintingRipped.value = true;
                this.GetComponent<BoxCollider2D>().enabled = false;

                PlayerPrefs.SetInt("usingItem", 0);

                objs = GameObject.FindGameObjectsWithTag("Button");
                foreach (GameObject button in objs)
                {
                    button.GetComponent<Button>().interactable = true;
                }

                i_contents.content[slot.GetComponent<InventorySlot>().slotID] = null;

                for (var i = slot.transform.childCount - 1; i >= 0; i--)
                {
                    Object.Destroy(slot.transform.GetChild(i).gameObject);
                }

            }

            else
            {
                Debug.Log("Wrong Item");
            }
         }
    }
}
