using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IceMachine.iceHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IceMachine.iceHit = false;
    }
}