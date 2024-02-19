using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem particle;
    public string particleName;

    
    // Start is called before the first frame update
    /*void Start()
    {
       
    }*/

    public void InstaniateVFX()
    {
        ParticleSystem particleLoad = Resources.Load(particleName, typeof(ParticleSystem)) as ParticleSystem;
        ParticleSystem ParticleSystem = Instantiate(particleLoad, transform.position, Quaternion.identity);
        ParticleSystem.transform.SetParent(transform);
    }
    public void VFXStart() 
    {
        particle.Play();
        particle.enableEmission= true;
    }
    public void VFXStop()
    {
        particle.enableEmission = false;
    }
    private void OnDestroy()
    {
        particle.enableEmission = false;
    }
}
