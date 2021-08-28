using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyParticle : MonoBehaviour
{
    public void DestroyParticle(float time)
    {
        StartCoroutine(destroyparticle(time));
    }

    public IEnumerator destroyparticle(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}