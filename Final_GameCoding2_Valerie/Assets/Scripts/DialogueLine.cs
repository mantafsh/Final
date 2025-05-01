using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "DialogueLine/Object")]
//SO is a data container, allows you to store a large amount of shared data independent from a script
public class DialogueLine : ScriptableObject
{
    public string speakerName;
    [TextArea] public List<string> dialogueLinesList = new List<string>();
    //list of text to show 
    //[TextArea] public string textLine;

    //next line if no choices
    public DialogueLine nextLine;
    //choices if there are any
    public DialogueChoice[] choices;


}

[System.Serializable]
public class DialogueChoice
{
    public string choiceText; //what the choice says
    public DialogueLine nextLine; //what happens if you pick it

    public string requiredStat;
    public int requiredValue;

    public string rewardStat;
    public int rewardAmt;

}
