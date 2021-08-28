using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour
{
    public ShrinkOnInterval shrinkoninterval;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shrinkoninterval.canShrink = true;
            shrinkoninterval.canGrow = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shrinkoninterval.canShrink = true;
        }
    }
}