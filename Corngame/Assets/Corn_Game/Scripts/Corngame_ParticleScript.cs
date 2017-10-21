using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corngame_ParticleScript : MonoBehaviour
{
    //SCript for calling PArticle

    [SerializeField] GameObject Exploding_Particles;
    SFXScript sfxscript;


    public void Spawn_Particles()
    {
        GameObject particle = Instantiate(Exploding_Particles, new Vector3(0, 0, -3), Quaternion.identity) as GameObject;
        particle.name = "Particle";

    }




}
