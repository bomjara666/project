using UnityEngine;

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
        // ��������� ������������ � �������
        if (other.CompareTag("Player"))
        {
            Plane plane = other.GetComponent<Plane>();
            if (plane != null)
            {
                plane.UpdateLife(-damageToPlayer);

                // ���������� ParticleSystem �� ��������
                ParticleSystem planeParticles = plane.GetComponent<ParticleSystem>();
                if (planeParticles != null)
                {
                    planeParticles.Play();
                }
            }

            // ���������� ������
            Destroy(gameObject);
        }
        // ��������� ������������ � ���������
        else if (other.TryGetComponent<Plane>(out var plane))
        {
            plane.UpdateLife(-1);

            // ���������� ParticleSystem �� ��������
            ParticleSystem planeParticles = plane.GetComponent<ParticleSystem>();
            if (planeParticles != null)
            {
                planeParticles.Play();
            }

            // ���������� ������
            Destroy(gameObject);
        }
    }

// ��������� ����� ��� ��������������� �������
private void PlayExplosionEffect()
{
    if (explosionEffect != null)
    {
        // ������� ������ � ����������� ���
        ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        
        // �������������� ����������� ������� ����� ����������
        Destroy(explosion.gameObject, explosion.main.duration);
        
        // ��������� �������
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
