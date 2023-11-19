using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandelQuiteButton()
    {
        AudioManager.Play(AudioClipName.ClicButton);
        Destroy(gameObject);    
    }
}
