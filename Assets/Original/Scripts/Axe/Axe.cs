using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public ParticleSystem woodParticle;
    public ParticleSystem rockParticle;

    Dictionary<string, ParticleSystem> particles =
    new Dictionary<string, ParticleSystem>();

    void Awake()
    {
        particles.Add("Wood", woodParticle);
        particles.Add("Rock", rockParticle);
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter: " + col.gameObject.tag);

        if (col.relativeVelocity.sqrMagnitude <= 1.0f * 1.0f)
        {
            return;
        }

        var colTag = col.gameObject.tag;
        if (!particles.ContainsKey(colTag))
        {
            return;
        }

        if (col.contacts.Length <= 0)
        {
            return;
        }

        var contact = col.contacts[0];
        debugDrawContact = contact;

        var hitPos = contact.point;
        var hitNormal = contact.normal;

        var particle = particles[colTag];
        particle.gameObject.transform.position = hitPos;
        particle.gameObject.transform.LookAt(hitPos + hitNormal);
        particle.Play();
    }

    ContactPoint? debugDrawContact;
    /*
    void OnDrawGizmos()
    {
        if (debugDrawContact.HasValue)
        {
            var contact = debugDrawContact.Value;
            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(contact.point, contact.normal * -1.0f);
        }
    }
    */
}
