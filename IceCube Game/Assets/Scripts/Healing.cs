using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public ShrinkOnInterval shrinkOnInterval;

    public Building building;

    private int amount1;
    private int amount2;
    private int amount3;

    public static bool random1;
    public static bool random2;
    public static bool random3;

    private void Update()
    {
        GameObject[] factories1 = GameObject.FindGameObjectsWithTag("Point1");
        GameObject[] factories2 = GameObject.FindGameObjectsWithTag("Point2");
        GameObject[] factories3 = GameObject.FindGameObjectsWithTag("Point3");
        amount1 = factories1.Length;
        amount2 = factories2.Length;
        amount3 = factories3.Length;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shrinkOnInterval.canGrow = true;
            if (random1 == true)
            {
                if (amount1 != building.SpawnPoints.Length)
                {
                    shrinkOnInterval.canGrow = false;
                }

                if (amount1 == 0)
                {
                    shrinkOnInterval.canGrow = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shrinkOnInterval.canGrow = false;
            shrinkOnInterval.canShrink = true;
        }
    }
}