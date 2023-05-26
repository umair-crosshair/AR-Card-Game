using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSliderToProgressbar : MonoBehaviour
{
    private Slider slider;
    
    [SerializeField]private ProgressBarPro progressBar;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void RefreshProgressBar()
    {
        float currentValue = slider.value / slider.maxValue;
        progressBar.SetValue(currentValue);
    }
}
