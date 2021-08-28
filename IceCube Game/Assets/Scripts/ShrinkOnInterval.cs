using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class ShrinkOnInterval : MonoBehaviour
{
    public GameObject[] iceCubeLevels;

    public bool canShrink = false;
    public bool canGrow = false;
    public bool Fire = false;
    public bool FireHit = true;
    private bool deathTimerDone = false;

    public int amountOfShrinks;
    public float shrinkEveryXSeconds;
    public float shrinkEveryXSeconds2;
    public float GrowEveryXSeconds;

    float sizeDecrease = 0f;
    private float sizeIncrease = 0f;
    public static float currentSize = 0f;
    private float elapsedTime = 0f;
    private float elapsedTime2 = 0f;
    private float elapsedTime3 = 0f;
    private float deathTimer = 1f;

    public static int ShrinksLeft = 0;

    public List<GameObject> Cubes;

    public Image TemperatureIcon;

    public Color heatColor;
    public Color coldColor;

    void Awake()
    {
        ShrinksLeft = amountOfShrinks;
        currentSize = transform.localScale.x;

        sizeDecrease = currentSize / (float)amountOfShrinks;
        sizeIncrease = currentSize / (float)amountOfShrinks;

        TemperatureIcon.color = coldColor;
    }

    void Update()
    {
        if (deathTimerDone == true)
        {
            deathTimer -= Time.deltaTime;
        }

        if (canShrink == true && ShrinksLeft > 0)
        {
            TemperatureIcon.color = heatColor;
            elapsedTime += Time.deltaTime;
            if (elapsedTime > shrinkEveryXSeconds)
            {
                elapsedTime = 0f;

                if (ShrinksLeft == 6)
                {
                    iceCubeLevels[0].SetActive(false);
                    iceCubeLevels[1].SetActive(true);
                }

                if (ShrinksLeft == 5)
                {
                    iceCubeLevels[1].SetActive(false);
                    iceCubeLevels[2].SetActive(true);
                }

                if (ShrinksLeft == 4)
                {
                    iceCubeLevels[2].SetActive(false);
                    iceCubeLevels[3].SetActive(true);
                }

                if (ShrinksLeft == 3)
                {
                    iceCubeLevels[3].SetActive(false);
                    iceCubeLevels[4].SetActive(true);
                }

                if (ShrinksLeft == 2)
                {
                    iceCubeLevels[4].SetActive(false);
                    iceCubeLevels[5].SetActive(true);
                }

                if (ShrinksLeft == 1)
                {
                    iceCubeLevels[5].SetActive(false);
                }

                if (ShrinksLeft == 0)
                {
                    ShrinkZero();
                }

                Shrink();
            }
        }

        //if (Fire == true)
        //{
        //    canShrinkIcon.SetActive(true);
        //    canGrowIcon.SetActive(false);
        //    if (FireHit == true)
        //    {
        //        elapsedTime3 = 0f;

        //        currentSize -= sizeDecrease;
        //        if (currentSize < 0)
        //        {
        //            currentSize = 0f;
        //        }

        //        ShrinkFire(currentSize);
        //        FireHit = false;
        //    }
        //    elapsedTime3 += Time.deltaTime;
        //    if (elapsedTime3 > shrinkEveryXSeconds2)
        //    {
        //        FireHit = true;
        //    }
        //}

        if (canGrow == true)
        {
            TemperatureIcon.color = coldColor;
            canShrink = false;
            if (ShrinksLeft < 6)
            {
                elapsedTime2 += Time.deltaTime;
                if (elapsedTime2 > GrowEveryXSeconds)
                {
                    elapsedTime2 = 0f;

                    if (ShrinksLeft == 1)
                    {
                        iceCubeLevels[5].SetActive(false);
                        iceCubeLevels[4].SetActive(true);
                    }

                    if (ShrinksLeft == 2)
                    {
                        iceCubeLevels[4].SetActive(false);
                        iceCubeLevels[3].SetActive(true);
                    }

                    if (ShrinksLeft == 3)
                    {
                        iceCubeLevels[3].SetActive(false);
                        iceCubeLevels[2].SetActive(true);
                    }

                    if (ShrinksLeft == 4)
                    {
                        iceCubeLevels[2].SetActive(false);
                        iceCubeLevels[1].SetActive(true);
                    }

                    if (ShrinksLeft == 5)
                    {
                        iceCubeLevels[1].SetActive(false);
                        iceCubeLevels[0].SetActive(true);
                    }

                    if (ShrinksLeft == 0)
                    {
                        ShrinkZero();
                    }
                    Grow();
                }
            }    
        }
    }

    private void Shrink()
    {
        TemperatureIcon.color = coldColor;
        CameraShake.Instance.ShakeCamera(3f, 0.1f);
        Vector3 punch = new Vector3(0.5f, 0.5f, 1f);
        transform.DOPunchScale(punch, 0.5f, 1, 1f);
        PlayerMovement.moveSpeed += 10;
        Cubes[ShrinksLeft - 1].SetActive(false);
        ShrinksLeft -= 1;

        if (ShrinksLeft == 0)
        {
            ShrinkZero();
        }
    }

    //private void ShrinkFire(float currentSize)
    //{
    //    CameraShake.Instance.ShakeCamera(2f, 0.1f);
    //    PlayerMovement.moveSpeed += 10;
    //    Cubes[ShrinksLeft - 1].SetActive(false);
    //    ShrinksLeft -= 1;
    //    transform.localScale = new Vector2(currentSize, currentSize);

    //    if (currentSize <= 0.1f)
    //    {
    //        ShrinkZero();
    //    }
    //}

    public void Grow()
    {
        CameraShake.Instance.ShakeCamera(3f, 0.1f);
        PlayerMovement.moveSpeed -= 10;
        Cubes[ShrinksLeft].SetActive(true);
        ShrinksLeft += 1;
    }

    private void ShrinkZero()
    {
        CameraShake.Instance.ShakeCamera(5f, 1f);
        SceneManager.LoadScene("DeathScreen");
    }
}