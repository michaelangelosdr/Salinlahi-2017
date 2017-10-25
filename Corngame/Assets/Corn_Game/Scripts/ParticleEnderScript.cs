using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnderScript : MonoBehaviour {

	private ParticleSystem Particle_system;


    private void Start()
    {
        Particle_system = GetComponent<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (!Particle_system.isPlaying)
        {
	gameObject.SetActive (false);

        }
    }


}
