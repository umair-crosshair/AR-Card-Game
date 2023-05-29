using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject redSlash;
    [SerializeField] private GameObject electroSlash;


    public void SwitchSlash(bool isElectro)
    {
        if (isElectro)
        {
            Debug.Log("Switching to electro");
            electroSlash.SetActive(true);
            redSlash.SetActive(false);
        }
        else
        {
            Debug.Log("Switching to fire");
            electroSlash.SetActive(false);
            redSlash.SetActive(true);
        }
    }

}
