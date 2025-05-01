using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    //reference to scriptable object
    public DialogueLine currentLine;
    //container for dialogue lines
    public Transform dialogueParent;
    public GameObject dialoguePrefab;
    //prefab for button choices
    public GameObject choiceButtonPrefab;
    //container for button choices
    public Transform choiceParent;
    public Button continueButton;

    public void StartingDialogue()
    {
        UpdateDialogue(currentLine);
    }
    public void UpdateDialogue(DialogueLine dialogueline)
    {

        currentLine = dialogueline;
        StartCoroutine(DisplayDialogue(currentLine));
        //optional
        continueButton.enabled = true;

    }
    IEnumerator DisplayDialogue(DialogueLine line)
    {
        foreach (string _dialogueLine in currentLine.dialogueLinesList)
        {
            //make new copy of button
            GameObject textBubble = Instantiate(dialoguePrefab, dialogueParent);
            //grab getcomponentinchildren
            TextMeshProUGUI grabText = textBubble.GetComponentInChildren<TextMeshProUGUI>();
            Image grabImage = textBubble.GetComponentInParent<Image>();
            // grabImage.enabled = false;
            //set the text to whatever string we are currently looping
            grabText.text = _dialogueLine;
            if (!string.IsNullOrEmpty(line.speakerName))
            {

                grabText.text = $"<b>{line.speakerName}:</b> {_dialogueLine}";
                ////change color based on the speaker
                //if (line.speakerName.Contains("meow"))
                //{
                //    Debug.Log("Speaker known");
                //    //grabImage.GetComponent<Image>().color = new Color(205, 221, 255);
                //    grabImage.color = new Color32(205, 221, 255, 100);
                //    Debug.Log("color changerd");
                //}
                //else if (line.speakerName.Contains("You"))
                //{
                //    grabImage.color = new Color32(202, 236, 178, 100);
                //    //change text alignment (doesn't work yet :(
                //    grabText.alignment = TextAlignmentOptions.TopRight;
                //}

            }
            //grey out text
            yield return new WaitForSeconds(1f);
            //grabText.text = $"<color=grey><b>{line.speakerName}:</b> {_dialogueLine}</color>";
        }
        //set continue button below all text
        continueButton.transform.SetAsLastSibling();
        //clear old choice buttons so they don't stack
        foreach (Transform _child in choiceParent) Destroy(_child.gameObject);
        //hide the continue button by default
        continueButton.gameObject.SetActive(false);
        //button choices appear after the chat line
        choiceParent.transform.SetAsLastSibling();

        if (line.choices != null && line.choices.Length > 0)
        {
            foreach (DialogueChoice choice in line.choices)
            {
                //create a button
                GameObject newButtonChoice = Instantiate(choiceButtonPrefab, choiceParent);
                //come back to when we have options
                TextMeshProUGUI buttonText = newButtonChoice.GetComponentInChildren<TextMeshProUGUI>();

                bool meetsRequirement = true;
                //if required stat field isn't empty
                if (!string.IsNullOrEmpty(choice.requiredStat))
                {
                    //checks player stats and returns the current value stored in variable
                    //int playerStat = GetPlayerStatValue(choice.requiredStat);
                    //checks if its greater than or equal to required value
                    int playerStat = PlayerStats.Instance.GetStat(choice.requiredStat);
                    meetsRequirement = playerStat >= choice.requiredValue;
                }

                //button text
                buttonText.text = choice.choiceText;
                if (!meetsRequirement)
                {
                    //buttonText.text += "<color = red>" + choice.requiredStat + ": " + choice.requiredValue + "</color>";

                    buttonText.text += $"<color=red>({choice.requiredStat} : {choice.requiredValue})</color>";
                }

                // grab the button component of  the choice button 

                Button buttonComp = newButtonChoice.GetComponent<Button>();
                buttonComp.onClick.AddListener(() =>
                {
                    if (!string.IsNullOrEmpty(choice.rewardStat))
                    {
                        PlayerStats.Instance.IncreaseStat(choice.rewardStat, choice.rewardAmt);
                    }
                });

                buttonComp.interactable = meetsRequirement;
                if (meetsRequirement)
                {
                    newButtonChoice.GetComponent<OptionalChoices>().SetUp(this, choice.nextLine, choice.choiceText);

                }
            }
        }
        else if (line.nextLine != null)
        {
            //if there are no choices but there is a next line show a continue button
            continueButton.gameObject.SetActive(true);
            //clear out everything that is set to happen
            //bc we are using the same button for different lines &  we don't want them to stack
            continueButton.onClick.RemoveAllListeners();
            //when button is clicked run this code
            continueButton.onClick.AddListener(() =>
            {
                //continue to next line
                UpdateDialogue(line.nextLine);
                continueButton.gameObject.SetActive(false);

            });
        }

    }
}
