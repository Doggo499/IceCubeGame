using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public delegate void buildingEvent(int amountOfFactories);
    public static event buildingEvent onBuildingSpawn;
    public static event buildingEvent onFactoryDestroyed;

    public Transform[] SpawnPoints;
    public bool[] SpawnPointsFilled;

    public GameObject FactoryPrefab;
    public List<GameObject> LevelWalls;

    private int Control;
    public int amountOfFactories = 40;

    [HideInInspector]
    public bool GeneratedLevel;

    private bool canParticle = true;
    public float EndTimer;

    public ParticleSystem winningParticle;

    private void Start()
    {
        SpawnPointsFilled = new bool[SpawnPoints.Length];
    }

    private IEnumerator SpawnFactories(int amount)
    {
        while (Control < amount)
        {
            //int randomFactory = Random.Range(0, FactoryPrefabs.Length);
            int randomSpawnPoints = Random.Range(0, SpawnPoints.Length);
            if (SpawnPointsFilled[randomSpawnPoints] == false)
            {
                Healing.random1 = true;
                Factory factorySpawn = Instantiate(FactoryPrefab, SpawnPoints[randomSpawnPoints].position, transform.rotation).GetComponent<Factory>();
                factorySpawn.SetBuilding(this);
                SpawnPointsFilled[randomSpawnPoints] = true;
                Control++;
                FactoryPrefab.tag = "Point1";
                yield return new WaitForSeconds(0.01f);
            }
        }

        onBuildingSpawn?.Invoke(amountOfFactories);

        yield return null;
    }

    public void DestroyedFactory(Factory factory)
    {
        amountOfFactories--;
        onFactoryDestroyed?.Invoke(amountOfFactories);
    }

    private void Update()
    {
        if (amountOfFactories == 0)
        {
            EndTimer -= Time.deltaTime;
            if (canParticle == true)
            {
                //i am not sure if i would do it but oki
                CameraShake.Instance.ShakeCamera(5f, 1f);
                winningParticle.Play();
                canParticle = false;
            }

            if (EndTimer <= 0)
            {
                LevelWalls[0].SetActive(false);
                //SceneManager.LoadScene("WinScreen");
            }
        }
    }

    public void Trigger()
    {
        StartCoroutine(SpawnFactories(amountOfFactories));
    }
}