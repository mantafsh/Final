using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCounter : MonoBehaviour
{
    public static TextMeshProUGUI combo;
    public static int startingCombo = 0;
    public static int currentCombo;
    // Start is called before the first frame update
    void Start()
    {
        combo = GetComponent<TextMeshProUGUI>();
    }

    public static void ComboUpdate()
    {
        
        currentCombo++;
        combo.text = "Combo: " + currentCombo.ToString();

    }
    public static void ResetCombo()
    {
        currentCombo = startingCombo;
        combo.text = "Combo: " + currentCombo.ToString();
    }
}
