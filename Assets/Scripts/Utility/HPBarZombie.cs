using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarZombie : MonoBehaviour
{
    public Slider slider;
    public Image fillHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaxHPZombie(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }    
    public void SetHPZombie(int health)
    {
        slider.value = health;
        
    } 
    public void DisableHPBar(bool enable)
    {
        
    }
    
}
