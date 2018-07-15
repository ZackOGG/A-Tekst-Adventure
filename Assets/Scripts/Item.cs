using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "my name is buba", menuName = "Item")]
public class Item : ScriptableObject
{
    public Item_Type itemType;
    public string itemName;
    //[Tooltip("How many times it can be used before destoyed. EG a potion can have two doses but a tinderbox might have 20. If -1 then there is no limit" )]
    //public int charges;
    //[Tooltip("The mesage when inspected")]
    //public string inspectionMsg;
    //[Tooltip("The message when the item runes out of charges")]
    //public string usedUpMeg;
    //public bool useable;
}
