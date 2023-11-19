using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initialization : MonoBehaviour
{
    [SerializeField]
    private GameObject steef;
    [SerializeField]
    private  GameObject pliers;

    [SerializeField]
    private GameObject bakra;
    [SerializeField]
    private GameObject nut;

    [SerializeField]
    ArabicText text;
    private void Awake()
    {
        EventManager.Initialize();
        HUD.Initilaze(text);
        TaskManager.intiliz(steef, pliers,bakra,nut);
        
       
    }
}
