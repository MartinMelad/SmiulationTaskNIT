using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class HUD 
{
    static ArabicText text;
    static string newText;

    public static void SetText(string textt)
    {
        text.Text = textt;
    }

    public static void Initilaze(ArabicText textt)
    {
        text = textt;
    }
}
