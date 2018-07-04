using UnityEngine;

enum Options {Go_North, Go_East, Go_South, Go_West, Open_Inventory, Talk_To_NPC, Investigae_Area }


[System.Serializable]
public class OptionContents
{
    [Tooltip("Where you see the node and what it is EG: To the north you see a town ")]
    public string nodeDescription; 
    [Tooltip("What the option will show do not capitalise")]
    public string optionText; 
    [Tooltip ("The node this option will lead to")]
    public Node_Controller nextNode;
    [Tooltip ("The description of how the action is carried out")]
    public string carryOutText;
    [Tooltip ("Is an Item needed")]
    public ItemNeeded itemNeeded;
}

[System.Serializable]
public class ItemNeeded
{
    public bool needItem = false;
    public Item item;
}
[System.Serializable]
public struct Item
{
    public string itemName;
}