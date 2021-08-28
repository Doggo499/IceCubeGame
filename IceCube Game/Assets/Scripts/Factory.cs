using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private Building building;

    private SoundManager soundManager;
    public SelfDestroyParticle selfDestroyParticle;

    public void SetBuilding(Building building)
    {
        this.building = building;
    }

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraShake.Instance.ShakeCamera(4f, 0.2f);

            building.DestroyedFactory(this);

            soundManager.DestroySound();
            SelfDestroyParticle particle = Instantiate(selfDestroyParticle, transform.position, Quaternion.identity, null);
            particle.DestroyParticle(1f);
            Destroy(gameObject);
        }
    }
}