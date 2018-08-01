using UnityEngine;

enum Options {Go_North, Go_East, Go_South, Go_West, Open_Inventory, Talk_To_NPC, Investigae_Area }
public enum Item_Type {Weapon, Consumable, Miscellaneous}
public enum ItemOptions {Open_Lock, Attack, Consume}
public enum LocksAndKeys {Gold, Silver, Bronze }


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
    [Tooltip ("Is it an investigation")]
    public bool investigate;
    [Tooltip ("This is the text desplayed about their investigation")]
    public string investigationText;
}

[System.Serializable]
public class ItemNeeded
{
    public bool needItem = false;
    public Item_ImplementOut item;
}

[System.Serializable]
public class ItemOptionConstructior  // This is what can be done with the item
{
    public ItemOptions theItemsOption;
    public string inspectText;
    public string consumdeDescription;
    public bool destroyable;
    public string destroyText;
    public LocksAndKeys KeyColour;

    
}


[System.Serializable]
public struct Item_ImplementOut
{
    public string itemName;
    public bool isWeapon;
    public int damage;
    public bool isConsumable;
}

