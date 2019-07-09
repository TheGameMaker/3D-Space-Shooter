using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteStars : MonoBehaviour {

    private Transform tx;
    private ParticleSystem stars;
    private ParticleSystem.Particle[] points;

    public int starsMax = 100;
    public float starSize = 1.0f;
    public float starDistance = 10f;
    private float sqrStarDistance;

	// Use this for initialization
	void Start () {
        tx = transform;
        stars = tx.GetComponent<ParticleSystem>();
        sqrStarDistance = starDistance * starDistance;
	}

    //Creates Stars
    private void CreateStars()
    {
        points = new ParticleSystem.Particle[starsMax];

        for (int i = 0; i < starsMax; i++)
        {
            points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            points[i].color = new Color(1, 1, 1, 1);
            points[i].size = starSize;
        }

    }

	// Update is called once per frame
	void Update () {
		if (points == null)
        {
            CreateStars();
        }

        for (int i = 0; i < starsMax; i++)
        {
            if((points[i].position - tx.position).sqrMagnitude > sqrStarDistance )
            {
                points[i].position = Random.insideUnitSphere * starDistance + tx.position;
            }
        }

        stars.SetParticles(points, points.Length);
	}
}
