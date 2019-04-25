using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    public abstract IEnumerator ExecuteSkill(Battler user, Battler[] targets);
    public abstract int GetMPCost();
    public abstract string GetName();

    public IEnumerator CreateParticles(int gfxID, float waitTimeMulyiplier, Vector3 position)
    {
        GameObject particlesObjects = GameObject.Instantiate(GFXManager.Instance.gfxPrefabs[gfxID], position, Quaternion.identity);
        ParticleSystem particles = particlesObjects.GetComponent<ParticleSystem>();
        float time = particles.main.duration + particles.main.startLifetime.constant;
        GameObject.Destroy(particlesObjects, time);
        yield return new WaitForSeconds(time * waitTimeMulyiplier);
    }
}
