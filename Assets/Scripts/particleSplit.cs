using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSplit : MonoBehaviour
{
    private Transform _parent;
    private ParticleSystem _curParticleSystem;

    public void Detach()
    {
        _parent = transform.parent;

        // splits the particle off so it doesn't get deleted with the parent
        transform.parent = null;

        _curParticleSystem = GetComponent<ParticleSystem>();
        if (null == _curParticleSystem)
        {
            return;
        }

        // stops the particle from creating more bits
        _curParticleSystem.Stop();
    }
}
