using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Controller : MonoBehaviour {
    
    [Header("Direction Locations")]
    [SerializeField] string thisLocationText;
    [SerializeField] OptionContents optionOneNode;
    [SerializeField] OptionContents optionTwoNode;
    [SerializeField] OptionContents optionThreeNode;
    [SerializeField] OptionContents optionFourNode;
    [SerializeField] OptionContents optionFiveNode;
    [SerializeField] OptionContents optionSixNode;

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

    // Use this for initialization
    void Start ()
    {
        OpeningDescription();
        ReadOptions();
	}
	
    private void OpeningDescription()
    {
        //Read the opening description
        print(thisLocationText + " " + optionOneNode.nodeDescription + " " + optionTwoNode.nodeDescription + " " + optionThreeNode.nodeDescription + " " + optionFourNode.nodeDescription + " " + optionFiveNode.nodeDescription + " " + optionSixNode.nodeDescription + "What would you like to do?");
    }
    private void ReadOptions()
    {
        //Change button one to read option one + Text
        //Change button two to read option two + Text
        //Change button three to read option three + Text
        //change button four to read option four + Text 

        print(userInputOptionOneText + " " + optionOneNode.optionText);
        print(userInputOptionTwoText + " " + optionTwoNode.optionText);
        print(userInputOptionThreeText + " " + optionThreeNode.optionText);
        print(userInputOptionFourText + " " + optionFourNode.optionText);
        print(userInputOptionFiveText + " " + optionFiveNode.optionText);
        print(userInputOptionSixText + " " + optionSixNode.optionText);
    }

    private void Update()
    {
        if(waitingForPlayer)
        {

        }
       
    }

    private void WaitingForPlayer() // Waiting for the player to pick inital option
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
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
