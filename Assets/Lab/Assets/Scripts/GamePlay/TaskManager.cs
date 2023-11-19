using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskManager
{
    #region  Fields
    private static GameObject staaf;
    private static GameObject pliers;
    private static GameObject bakra;
    private static GameObject nut;

    private static Outline outlineStaaf;
    private static Outline outlinePliers;
    private static Outline outlineBakra;
    private static Outline outlineNut;

    public static int TaskNumber = 0;

    // for outline timer
    static  float timer = 0f;
    static float timerDuration = .5f;
    #endregion

    #region prop
    public static string toolNameToDoTask { get; set; }
    public static float RutateDir { get; set; }
    #endregion

    #region public Methods


    public static void GotToNextStep()
    {
        TaskNumber++;   
        switch (TaskNumber) 
        {
            case 1:
                // play sound
                // desplay 
                toolNameToDoTask = "Staaf";
                bakra.GetComponent<Task>().initializeTask("Staaf",false);
                AudioManager.Play(AudioClipName.BakraFak);
                HUD.SetText("قم بامساك المفك بالضغط علية \n اضغط علي البكره و حرف ال E لفك البكرة");
                break;
            case 2:
                toolNameToDoTask = "pliers";
                nut.GetComponent<Task>().initializeTask("pliers", false);
                AudioManager.Play(AudioClipName.NutFak);
                HUD.SetText("قم بامساك البنسة بالضغط عليها \n اضغط علي الصامولة و حرف ال E لفك الصامولة");
                break;
            case 3:
                toolNameToDoTask = "Set1";
                outlineNut.enabled = true;
                AudioManager.Play(AudioClipName.NutReturn);
                HUD.SetText("قم بالضغط علي الصامولة لاعادتها مكانها");
                break;
            case 4:
                toolNameToDoTask = "pliers";
                nut.GetComponent<Task>().initializeTask("pliers", true);
                AudioManager.Play(AudioClipName.NutRpt);
                HUD.SetText("قم بامساك البنسة بالضغط عليها \n اضغط علي الصامولة و حرف ال R لربط الصامولة");
                break;
            case 5:
                toolNameToDoTask = "Set2";
                outlineBakra.enabled = true;
                AudioManager.Play(AudioClipName.BakraReturn);
                HUD.SetText("قم بالضغط علي البكرة لاعاتها مكانها");
                break;
            case 6:
                toolNameToDoTask = "Staaf";
                AudioManager.Play(AudioClipName.BakraRpt);
                bakra.GetComponent<Task>().initializeTask("Staaf", true);
                HUD.SetText("قم بامسك المفك بالضغط علية \n اضغط علي البكره و حرف ال R لربط البكرة");
                break;
            default:
                AudioManager.Play(AudioClipName.Con);
                HUD.SetText("مبروك انجزت التاسك");
                break;
        }
    }


    public static void ActiveOutLineTool()
    {
        if (TaskNumber == 1 || TaskNumber == 6)
        {
            if (timer >= timerDuration)
            {
                outlineStaaf.enabled = !outlineStaaf.enabled;
                timer = 0f;
            }
            outlineBakra.enabled = false;
            timer += Time.deltaTime;

        }
        else if (TaskNumber == 2 || TaskNumber == 4)
        {
            if (timer >= timerDuration)
            {
                outlinePliers.enabled = !outlinePliers.enabled;
                timer = 0f;
            }
            timer += Time.deltaTime;
            outlineNut.enabled = false;
        }
    }


    public static void InActiveOutLineTool()
    {
        if (TaskNumber == 1 ||  TaskNumber == 6)
        {
            if (timer >= timerDuration)
            {
                outlineBakra.enabled = !outlineBakra.enabled;
                timer = 0f;
            }
            timer += Time.deltaTime;
            outlineStaaf.enabled = false;
        }
        else if (TaskNumber == 2 || TaskNumber == 4)
        {
            if (timer >= timerDuration)
            {
                outlineNut.enabled = !outlineNut.enabled;
                timer = 0f;
            }
            timer += Time.deltaTime;
            outlinePliers.enabled = false;
        }
    }


    public static void intiliz(GameObject st, GameObject pl, GameObject bak , GameObject ta)
    {
        
        pliers = pl;
        staaf = st;

        outlinePliers = pliers.GetComponent<Outline>();
        outlineStaaf = staaf.GetComponent<Outline>();

        bakra = bak;
        nut = ta;

        outlineBakra = bakra.GetComponent<Outline>();
        outlineNut = nut.GetComponent<Outline>();

        GotToNextStep();


    }

}


#endregion