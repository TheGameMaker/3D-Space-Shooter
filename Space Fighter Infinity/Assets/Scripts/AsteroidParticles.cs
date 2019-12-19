using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidParticles : MonoBehaviour {

    private Transform tx;
    private ParticleSystem stars;
    private ParticleSystem.Particle[] points;
   // [SerializeField] GameObject deathFX;

    public int starsMax = 100;
    public float starSize = 1.0f;
    public float starDistance = 10f;
    private float sqrStarDistance;

    // Use this for initialization
    void Start()
    {
        tx = transform;
        stars = tx.GetComponent<ParticleSystem>();
       // stars.collision.enableDynamicColliders.Equals(true);
        sqrStarDistance = starDistance * starDistance;
    }

    //Creates Stars
    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];
        //stars.collision.enableDynamicColliders.Equals(true);

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
           // points[i].color = new Color(1, 1, 1, 1);
            points[i].size = Random.value * starSize;
            points[i].rotation = Random.value * 180;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (points == null)
        {
            CreateStars();
        }

        for (int i = 0; i < starsMax; i++)
        {
            points[i].rotation++;
            if ((points[i].position - tx.position).sqrMagnitude > sqrStarDistance)
            {
                points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            }
        }

        stars.SetParticles(points, points.Length);
    }
}
