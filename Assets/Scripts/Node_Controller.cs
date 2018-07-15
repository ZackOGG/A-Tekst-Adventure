﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;

public class Node_Controller : MonoBehaviour {

    [Header("Direction Locations")]
    [SerializeField] string thisLocationText;
    [SerializeField] OptionContents[] optionsList;

    [Header("UI Text Locations")]
    [SerializeField] Text narationText;
    [SerializeField] Text[] textLocations;

    public void SetNarationText(Text narText)
    {
        narationText = narText;
    }
    public void SetTextLocations(Text[] textLoc)
    {
        textLocations = new Text[textLoc.Length];
        textLocations = textLoc;
    }
    [SerializeField] static string[] userInputText;
    


    [Header("Node Options")]
    [SerializeField] bool battle;
    [SerializeField] float duelKeyLatancy;

    public bool waitingForPlayer = true;
    public bool waitingToContinueToNextNode = false;
    public bool waitingToInvestigate = false;
    public bool waitingForInventoryOption = false;
    private int[] optionOrder;
    public OptionContents[] options = new OptionContents[6];
    public bool upAndDownPressed;
    public bool leftAndRightPressed;
    private Node_Controller selectedRoute;
    private Game_Manager gameManager;
    public static Vector3[] optionPosition;
    // Use this for initialization
   

    private void OnEnable()
    {
        if (optionsList.Length != 6)
        {
            Debug.LogError("Error: Node has less than 6 options. Do not delete options if you don't want that many options leave it blank.");
        }
        SetRefrences();
        SetInputText();
        OpeningDescription();
        SetOptions();
        ReadOptions();
    }

    private void SetRefrences()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<Game_Manager>();
    }
   

    private void SetInputText()
    {
        userInputText = new string[6];
        userInputText[0] = "Press the up arrow to ";
        userInputText[1] = "Press the right arrow to ";
        userInputText[2] = "Press the down arrow to ";
        userInputText[3] = "Press the left arrow to ";
        userInputText[4] = "Press both the up arrow and the down arrow to ";
        userInputText[5] = "Press both the left arrow and the right arrow to ";
    }

    private void OpeningDescription()
    {
        //Read the opening description
        narationText.text = thisLocationText + " " + optionsList[0].nodeDescription + " " + optionsList[1].nodeDescription + " " + optionsList[2].nodeDescription + " " + optionsList[3].nodeDescription + " " + optionsList[4].nodeDescription + " " + optionsList[5].nodeDescription + "What would you like to do?";

    }
    private void ReadOptions()
    {
        //Change button one to read option one + Text
        //Change button two to read option two + Text
        //Change button three to read option three + Text
        //change button four to read option four + Text 
        int arrayNum = 0;
        int newLocationInt = 0;
        foreach (OptionContents contents in options)
        {
            if(contents.optionText != "") // https://www.experts-exchange.com/questions/28076128/string-IsNullOrEmpty-throws-object-reference-is-null-error.html
            {
                //print(userInputText[arrayNum] + contents.optionText);
                textLocations[arrayNum].gameObject.SetActive(true);
                textLocations[arrayNum].text = contents.optionText;
                MoveOptionToLocation(textLocations[arrayNum].gameObject, newLocationInt);
                newLocationInt++;
            }
            else
            {
                textLocations[arrayNum].gameObject.SetActive(false);
                
                
            }

            arrayNum++;
        }

        waitingForPlayer = true;
    }


    private void Update()
    {
        if(waitingForPlayer)
        {
            WaitingForPlayer();
        }

        if(waitingToContinueToNextNode)
        {
            WaitingToContinueToNextNode();
        }
       
        if(waitingForInventoryOption)
        {
            print("Waiting for inventory OPTION");
        }

        if(waitingToInvestigate)
        {
            WaitingToInvestigate();
        }
    }

    private void WaitingForPlayer() // Waiting for the player to pick inital option
    {
        print("Waiting for player");
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) // Check to see if any input then check if it was a duel input
        {
            StartCoroutine(DetectDuelKeyLatancy());

            
        }
    }

    private void WaitingToContinueToNextNode()
    {
        print("Waiting to continue");
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            waitingToContinueToNextNode = false;
            ChangeNode(selectedRoute);
        }
    }

    private void WaitingToCheckInventory()
    {
        print("Waiting to finsihed checking inventory");
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {            
            waitingForInventoryOption = false;
            ReadOptions();
            OpeningDescription();
        }

    }

    private void WaitingToInvestigate() // Waiting for the player to continue from investigating
    {
        print("Waiting to finish investigating");
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            
            print("Test2");
            waitingToInvestigate = false;
            ReadOptions();
            OpeningDescription();
            
        }
    }     

    private void SetOptions() //Creates a foreach with the options list in that checks through them all for each one that is not blank and adds them to the options array.
    {
        int arrayNum = 0;
        
        foreach(OptionContents contents in optionsList)
        {
            if(!string.IsNullOrEmpty(contents.optionText))
            {
                options[arrayNum] = contents;
                
            }
            arrayNum++;
        }
        
    }

    private void AtemptAction()
    {
        //Read how the action happens
        //Make waiting for player false
        //Make waiting to continue true;
        //If an item is needed and the player set need an item to true
        
        if (Input.GetKey(KeyCode.UpArrow) && !upAndDownPressed && options[0].carryOutText != "")
        {        

            narationText.text = ("You " + options[0].optionText + " Press any arrow to continue");
            selectedRoute = options[0].nextNode;
            waitingForPlayer = false;
            if (options[0].investigate == true)
            {
                waitingToInvestigate = true;
                narationText.text = options[0].investigationText + (" Press any arrow to continue");
            }
            else
            {
                waitingToContinueToNextNode = true;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && !leftAndRightPressed && options[1].carryOutText != "")
        {
            narationText.text = ("You " + options[1].optionText + " Press any arrow to continue");
            selectedRoute = options[1].nextNode;
            waitingForPlayer = false;
            if (options[1].investigate == true)
            {
                waitingToInvestigate = true;
                narationText.text = options[1].investigationText + (" Press any arrow to continue");
            }
            else
            {
                waitingToContinueToNextNode = true;
            }

        }
        if (Input.GetKey(KeyCode.DownArrow) && !upAndDownPressed && options[2].carryOutText != "")
        {
            narationText.text = ("You " + options[2].optionText + " Press any arrow to continue");
            selectedRoute = options[2].nextNode;
            waitingForPlayer = false;
            if (options[2].investigate == true)
            {
                waitingToInvestigate = true;
                narationText.text = options[2].investigationText + (" Press any arrow to continue");
            }
            else
            {
                waitingToContinueToNextNode = true;
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow) && !leftAndRightPressed && options[3].carryOutText != "")
        {
            narationText.text = ("You " + options[3].optionText + " Press any arrow to continue");
            selectedRoute = options[3].nextNode;
            waitingForPlayer = false;
            if (options[3].investigate == true)
            {
                waitingToInvestigate = true;
                narationText.text = options[3].investigationText + (" Press any arrow to continue");
            }
            else
            {
                waitingToContinueToNextNode = true;
            }

        }
        if (upAndDownPressed && options[4].carryOutText != "")
        {
            narationText.text = ("You " + options[4].optionText + " Press any arrow to continue");
            selectedRoute = options[4].nextNode;
            waitingForPlayer = false;
            if (options[4].investigate == true)
            {
                waitingToInvestigate = true;
                narationText.text = options[5].investigationText + (" Press any arrow to continue");
            }
            else if(options[4].optionText == "open inventory.")
            {
                print("Opening Inventory");
                waitingForPlayer = false;
                waitingForInventoryOption = true;
                ReadInventoryOptions();
            }
            else
            {
                waitingToContinueToNextNode = true;
            }
            upAndDownPressed = false;
        }
        if (leftAndRightPressed && options[5].carryOutText != "") // TODO This needs chaning for more flexability EG talk to npc
        {
            narationText.text = ("You " + options[4].optionText + " Press any arrow to continue");
            selectedRoute = options[5].nextNode;
            waitingForPlayer = false;
            
            if(options[5].investigate == true)
            {
                waitingToInvestigate = true;
                narationText.text = options[5].investigationText + (" Press any arrow to continue");
               
            }
            else
            {
                waitingForPlayer = true;
                selectedRoute = options[5].nextNode;
            }
            leftAndRightPressed = false;
            
        }
        //waitingForPlayer = true;
    }

    private void OptionToUseItem()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //set need an item to false
            //Execute options
        }
    }
    
    private void ChangeNode(Node_Controller nodeCon)
    {
        //Tell the game manager where to go next.
        
        gameManager.MoveToNode(nodeCon);
    }

   private void ReadInventoryOptions()
    {
        //Change button one to read option one + Text
        //Change button two to read option two + Text
        //Change button three to read option three + Text
        //change button four to read option four + Text 
        int arrayNum = 0;
        int newLocationInt = 0;
        foreach (Item theItem in gameManager.inventoryItems)
        {

            if (theItem != null) // https://www.experts-exchange.com/questions/28076128/string-IsNullOrEmpty-throws-object-reference-is-null-error.html
            {
                //print(userInputText[arrayNum] + contents.optionText);
                textLocations[arrayNum].gameObject.SetActive(true);
                textLocations[arrayNum].text = theItem.itemName;
                MoveOptionToLocation(textLocations[arrayNum].gameObject, newLocationInt);
                newLocationInt++;
            }
            else
            {
                textLocations[arrayNum].gameObject.SetActive(false);
            }
            arrayNum++;
        }

        waitingForPlayer = true;
    }

    private IEnumerator DetectDuelKeyLatancy()
    {
        waitingForPlayer = false;
        yield return new WaitForSeconds(duelKeyLatancy);
        if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            upAndDownPressed = true;
        }
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            leftAndRightPressed = true;
        }
        AtemptAction();
        
    }

    private void MoveOptionToLocation(GameObject obj, int location)
    {        
        Transform objTrans = obj.GetComponent<Transform>();
        objTrans.position = optionPosition[location];
    }
}

//TODO WAITING FOR PLAYER BEING TURNED ON WHEN SHOULD NOT BE