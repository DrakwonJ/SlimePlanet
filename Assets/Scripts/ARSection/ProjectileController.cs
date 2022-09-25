using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject targetMon;
    public ParticleSystem hitParticle;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //ParticleSystem particle = Instantiate(hitParticle);
        //particle.transform.position = collision.transform.position;
        //particle.Play();
        //Destroy(this);
    }
}
