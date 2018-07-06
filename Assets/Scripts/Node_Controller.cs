using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class Node_Controller : MonoBehaviour {
    
    [Header("Direction Locations")]
    [SerializeField] string thisLocationText;
    [SerializeField] OptionContents[] optionsList;

    [SerializeField] static string userInputOptionOneText = "Press the up arrow key to";
    [SerializeField] static string userInputOptionTwoText = "Press the right arrow key to";
    [SerializeField] static string userInputOptionThreeText = "Press the down arrow key to";
    [SerializeField] static string userInputOptionFourText = "Press the left arrow key to";
    [SerializeField] static string userInputOptionFiveText = "Press both the up and down arrow key to";
    [SerializeField] static string userInputOptionSixText =  "Press both the left and right arrow keys to";


    [Header("Node Options")]
    [SerializeField] bool battle;

    private bool waitingForPlayer = true;
    private bool waitingToContinue = false;
    private int[] optionOrder;
    public OptionContents[] options = new OptionContents[6];

    // Use this for initialization
    void Start ()
    {
        print(optionsList);
        if (optionsList.Length != 6)
        {
            Debug.LogError("Error: Node has less than 6 options. Do not delete options if you don't want that many options leave it blank.");
        }
        OpeningDescription();
        ReadOptions();
       
	}


    private void OpeningDescription()
    {
        //Read the opening description
        print(thisLocationText + " " + optionsList[0].nodeDescription + " " + optionsList[1].nodeDescription + " " + optionsList[2].nodeDescription + " " + optionsList[3].nodeDescription + " " + optionsList[4].nodeDescription + " " + optionsList[5].nodeDescription + "What would you like to do?");
    }
    private void ReadOptions()
    {
        //Change button one to read option one + Text
        //Change button two to read option two + Text
        //Change button three to read option three + Text
        //change button four to read option four + Text 

        print(userInputOptionOneText + " " + optionsList[0].optionText);
        print(userInputOptionTwoText + " " + optionsList[1].optionText);
        print(userInputOptionThreeText + " " + optionsList[2].optionText);
        print(userInputOptionFourText + " " + optionsList[3].optionText);
        print(userInputOptionFiveText + " " + optionsList[4].optionText);
        print(userInputOptionSixText + " " + optionsList[5].optionText);

        waitingForPlayer = true;
    }

    private void Update()
    {
        if(waitingForPlayer)
        {
            WaitingForPlayer();
        }
       
    }

    private void WaitingForPlayer() // Waiting for the player to pick inital option
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow))
        {
            AtemptActopn(options[0]);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AtemptActopn(options[1]);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.UpArrow))
        {
            AtemptActopn(options[2]);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            AtemptActopn(options[3]);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            AtemptActopn(options[4]);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            AtemptActopn(options[5]);
        }
    }

    private void SetOptions()
    {
        //NEXT Create a foreach with the options list in that checks through them all for each one that is not blank and adds them to the options array.
    }

    private void AtemptActopn(OptionContents optionCon)
    {
        //Read how the action happens
        //Make waiting for player false
        //Make waiting to continue true;
        //If an item is needed and the player set need an item to true
    }

    private void OptionToUseItem()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //set need an item to false
            //Execute options
        }
    }
    
    private void ExecuteOptions(Node_Controller nodeCon)
    {
        //Tell the node manager where to go next.
    }
}
