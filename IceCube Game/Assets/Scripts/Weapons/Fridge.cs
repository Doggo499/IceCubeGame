using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public ShrinkOnInterval shrinkoninterval;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shrinkoninterval.canGrow = true;
            shrinkoninterval.canShrink = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shrinkoninterval.canGrow = false;
            shrinkoninterval.canShrink = true;
        }
    }
}