using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSwitchController : MonoBehaviour
{
    [SerializeField] private SlashSwitcher[] slashes; 
     
    public void SwitchSlashes(bool isElectro)
    {
        if (isElectro)
        {
            foreach(SlashSwitcher ss in slashes)
            {
                ss.SwitchSlash(true);
            }
        }
        else
        {
            foreach (SlashSwitcher ss in slashes)
            {
                ss.SwitchSlash(false);
            }
        }
    }
}
