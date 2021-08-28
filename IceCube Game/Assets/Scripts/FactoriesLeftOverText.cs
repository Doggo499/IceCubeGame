using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FactoriesLeftOverText : MonoBehaviour
{
    public Building building;

    public TextMeshProUGUI FactoriesLeftText;
    public TextMeshProUGUI GetOutText;

    private float Timer = 5f;
    private bool timerTrue;

    private void Start()
    {
        GetOutText.enabled = false;
    }

    private void Update()
    {
        if (timerTrue == true)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer <= 0)
        {
            GetOutText.enabled = false;
            timerTrue = false;
            Timer = 5f;
        }
    }
    private void OnEnable()
    {
        Building.onBuildingSpawn += Building_onBuildingSpawn;
        Building.onFactoryDestroyed += Building_onFactoryDestroyed;
    }

    private void OnDisable()
    {
        Building.onBuildingSpawn -= Building_onBuildingSpawn;
        Building.onFactoryDestroyed -= Building_onFactoryDestroyed;
    }

    private void Building_onBuildingSpawn(int amountOfFactories)
    {
        FactoriesLeftText.text = "Factories Left : " + amountOfFactories;
    }

    private void Building_onFactoryDestroyed(int amountOfFactories)
    {
        FactoriesLeftText.text = "Factories Left : " + amountOfFactories;

        if (amountOfFactories == 0)
        {
            FactoriesLeftText.enabled = false;
            GetOutText.enabled = true;
            Vector3 punch = new Vector3(100f, 100f, 0f);
            GetOutText.transform.DOShakePosition(3, punch);
            timerTrue = true;
        }
    }
}