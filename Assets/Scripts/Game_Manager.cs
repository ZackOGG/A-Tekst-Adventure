using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    public Item[] inventoryItems;
    [SerializeField] int inventorySize;
    [Header("UI Text")]
    [SerializeField] Text[] optionsText;
    [SerializeField] Text narationText;

    [Tooltip("Set this as first node")]
    public Node_Controller activeNode;

    public Item testItem;
    public Item testItemTwo;
    public Vector3[] optionsPos;
    //===Getters and Setters===

    //=========================

    private void Start()
    {
        SetBagSize();
        SetOptionPos();
        StartFirstNode();
        AddItemToInventory(testItem);
        AddItemToInventory(testItemTwo);
        AddItemToInventory(testItemTwo);
        AddItemToInventory(testItemTwo);
        AddItemToInventory(testItemTwo);
        AddItemToInventory(testItemTwo);
        
    }

    private void StartFirstNode()
    {
        SetNewNodeUI();
        activeNode.gameObject.SetActive(true);
       
    }

    private void SetBagSize()
    {
        inventoryItems = new Item[inventorySize];
    }

    private void SetOptionPos()
    {
        optionsPos = new Vector3[6];
        optionsPos[0] = optionsText[0].gameObject.transform.position;
        optionsPos[1] = optionsText[1].gameObject.transform.position;
        optionsPos[2] = optionsText[2].gameObject.transform.position;
        optionsPos[3] = optionsText[3].gameObject.transform.position;
        optionsPos[4] = optionsText[4].gameObject.transform.position;
        optionsPos[5] = optionsText[5].gameObject.transform.position;
        Node_Controller.optionPosition = optionsPos;
    }

    public void MoveToNode(Node_Controller nodeCon)
    {
        
        
        activeNode.gameObject.SetActive(false);
        activeNode = nodeCon;
        SetNewNodeUI();
        activeNode.gameObject.SetActive(true);
    }

    private void SetNewNodeUI()
    {
        activeNode.SetNarationText(narationText);
        activeNode.SetTextLocations(optionsText);
        
    }

    //=====Inventory=====

    public void AddItemToInventory(Item item)
    {
        if(FindFreeInventorySlot() >= 0)
        {
            inventoryItems[FindFreeInventorySlot()] = item;
            // Set recived Item to true
        }
        else
        {
            Debug.Log("No free slots");
        }
    }

    public int FindFreeInventorySlot()
    {
        int indexNum = 0;
        foreach(Item itemSlot in inventoryItems)
        {
            if(itemSlot == null)
            {                
                return indexNum;
            }

            indexNum++;
        }
        return -1; 
    }
    //===================
}
