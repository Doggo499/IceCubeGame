using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public ShrinkOnInterval shrinkoninterval;

    public SpriteRenderer flame;
    public Collider2D flameCol;

    public static bool flameOn = true;
    public static bool flameHit = false;

    private bool one;

    private void Update()
    {
        if (flameHit == true)
        {
            shrinkoninterval.Fire = true;
            shrinkoninterval.canShrink = false;
            one = true;
        }
        else if (flameHit == false)
        {
            if (one == true)
            {
                shrinkoninterval.Fire = false;
                shrinkoninterval.canShrink = true;
                one = false;
            }
        }

        if (flameOn == true)
        {
            flame.enabled = true;
            flameCol.enabled = true;
        }

        if (flameOn == false)
        {
            flame.enabled = false;
            flameCol.enabled = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            flameOn = true;
        }
        else
        {
            flameOn = false;
        }
    }
}