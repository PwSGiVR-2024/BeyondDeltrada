using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
    }
    
    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}
