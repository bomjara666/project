using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Rocket : MonoBehaviour
{
    public float speed = 4f;
    public float rotationSpeed = 120f;
    public int damageToPlayer = 1;
    public ParticleSystem explosionEffect;
    private GameObject scoreManager;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().linearVelocity = -transform.right * speed;
        scoreManager = GameObject.Find("ScoreManager");
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


    private void PlayExplosionEffect()
    {
        if (explosionEffect != null)
        {
           
            ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

           
            Destroy(explosion.gameObject, explosion.main.duration);

           
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        Plane plane = other.GetComponent<Plane>();
        if (plane != null)
        {
            // Всегда наносим отрицательный урон (вычитаем жизни)
            int damage = damageToPlayer;
            plane.UpdateLife(-damage);

            // Воспроизводим эффект (если нужно)
            ParticleSystem planeParticles = plane.GetComponent<ParticleSystem>();
            if (planeParticles != null)
            {
                planeParticles.Play();
            }

            // Уничтожаем ракету
            Destroy(gameObject);
        }
    }
}