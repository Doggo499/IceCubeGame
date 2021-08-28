using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMachine : MonoBehaviour
{
    public ShrinkOnInterval shrinkoninterval;

    public SpriteRenderer ice;
    public Collider2D iceCol;

    private bool iceOn = false;
    public static bool iceHit = false;

    private bool one;

    private void Update()
    {
        if (iceHit == true)
        {
            shrinkoninterval.canGrow = true;
            shrinkoninterval.canShrink = false;
            one = true;
        }
        else if (iceHit == false)
        {
            if (one == true)
            {
                shrinkoninterval.canGrow = false;
                shrinkoninterval.canShrink = true;
                one = false;
            }
        }

        if (iceOn == true)
        {
            ice.enabled = true;
            iceCol.enabled = true;
        }

        if (iceOn == false)
        {
            ice.enabled = false;
            iceCol.enabled = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            iceOn = true;
        }
        else
        {
            iceOn = false;
        }
    }
}