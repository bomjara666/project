﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Rocket : MonoBehaviour
{
    public float speed = 4f;
    public float rotationSpeed = 120f;
    public int damageToPlayer = 1;
    public ParticleSystem explosionEffect;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().linearVelocity = -transform.right * speed;

        tag = "Rocket";
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ïðîâåðÿåì ñòîëêíîâåíèå ñ èãðîêîì
        if (other.CompareTag("Player"))
        {
            Plane plane = other.GetComponent<Plane>();
            if (plane != null)
            {
                plane.UpdateLife(-damageToPlayer);

                // Àêòèâèðóåì ParticleSystem íà ñàìîëåòå
                ParticleSystem planeParticles = plane.GetComponent<ParticleSystem>();
                if (planeParticles != null)
                {
                    planeParticles.Play();
                }
            }

            // Óíè÷òîæàåì ðàêåòó
            Destroy(gameObject);
        }
        // Ïðîâåðÿåì ñòîëêíîâåíèå ñ ñàìîëåòîì
        else if (other.TryGetComponent<Plane>(out var plane))
        {
            plane.UpdateLife(-1);

            // Àêòèâèðóåì ParticleSystem íà ñàìîëåòå
            ParticleSystem planeParticles = plane.GetComponent<ParticleSystem>();
            if (planeParticles != null)
            {
                planeParticles.Play();
            }

            // Óíè÷òîæàåì ðàêåòó
            Destroy(gameObject);
        }
    }

    // Îòäåëüíûé ìåòîä äëÿ âîñïðîèçâåäåíèÿ ýôôåêòà
    private void PlayExplosionEffect()
    {
        if (explosionEffect != null)
        {
            // Ñîçäàåì ýôôåêò è íàñòðàèâàåì åãî
            ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            // Àâòîìàòè÷åñêîå óíè÷òîæåíèå ýôôåêòà ïîñëå çàâåðøåíèÿ
            Destroy(explosion.gameObject, explosion.main.duration);

            // Çàïóñêàåì ÷àñòèöû
            explosion.Play();
        }
        else
        {
            Debug.LogWarning("Explosion effect not assigned!");
        }
    }

    public void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    public void TakeDamage(int dmg)
    {
        Explode();
    }
}