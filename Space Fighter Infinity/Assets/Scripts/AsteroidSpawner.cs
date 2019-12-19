using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Prefabs;
    private GameObject[] asteroids;

    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float maxDistance = 15f;
    [SerializeField] private float minSize = 0.2f;
    [SerializeField] private float maxSize = 2.0f;
    [SerializeField] private Vector3 offset;
    private Vector3 origin = Vector3.zero;
    [SerializeField] private int maxAmount = 100;
    private float sqrDistance;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position + offset;
        //asteroids = new GameObject[maxAmount];
        sqrDistance = maxDistance * maxDistance;
    }

    void GenerateAsteroids(int amount)
    {
        float size;
        asteroids = new GameObject[maxAmount];
        for (int i = 0; i < amount; i++)
        {
            // asteroids[i] = Prefabs[Random.Range(0, Prefabs.Length)];
            // size = Random.Range(minSize, maxSize);
            //  asteroids[i].transform.localScale = new Vector3(size, size, size);
            //  asteroids[i].transform.position = (Random.insideUnitSphere * (minDistance + (maxDistance - minDistance) * Random.value)) + origin;
            //  asteroids[i].transform.rotation = Random.rotation;
            // Instantiate(asteroids[i]);
            GenerateAsteroid(i);
        }
    }

    void GenerateAsteroid(int i)
    {
        asteroids[i] = Prefabs[Random.Range(0, Prefabs.Length)];
        float size = Random.Range(minSize, maxSize);
        asteroids[i].transform.localScale = new Vector3(size, size, size);
        asteroids[i].transform.position = (Random.insideUnitSphere * (minDistance + (maxDistance - minDistance) * Random.value)) + origin;
        asteroids[i].transform.rotation = Random.rotation;
        asteroids[i] = Instantiate(asteroids[i]);
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position + offset;
        if(asteroids == null)
        {
            GenerateAsteroids(maxAmount);
        }

        for(int i = 0; i < maxAmount; i++)
        {
            if (asteroids[i] == null)
            {
                GenerateAsteroid(i);
            }
            if ((asteroids[i].transform.position - transform.position).sqrMagnitude > sqrDistance)
            {
                Destroy(asteroids[i], 10.0f);
                GenerateAsteroid(i);
            }
        }
    }
}
