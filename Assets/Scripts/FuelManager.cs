using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelManager : MonoBehaviour
{
    public Image fuelBar;
    public static FuelManager instance;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
         DecreaseFuel();       
    }

    void DecreaseFuel()
    {
        if(fuelBar.fillAmount != 0)
        {
            fuelBar.fillAmount -= 0.03f * Time.deltaTime;
        }
        else if(fuelBar.fillAmount < 0)
        {
            fuelBar.fillAmount = 0;
        }
    }
    public void IncreaseFuel()
    {
        if(fuelBar.fillAmount != 0 && fuelBar.fillAmount != 1)
        {
           fuelBar.fillAmount += 0.15f;
        }
    }

}
