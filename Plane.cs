using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    [Header("���������")]
    private int lifeCounter;
    public float speed = 5f;
    public int moveDirection = 0;

    [SerializeField] private GameObject bulletPrefab; // ������ ����
    [SerializeField] private Transform spawnBulletPoint; // ����� ��������� ����
    [SerializeField] private TextMeshProUGUI lifeStatus;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private Image[] hearts;

    void Start()
    {
        InitializeLife();
    }

    void Update()
    {
        HandleMovement();
    }

    // ������������� ������
    private void InitializeLife()
    {
        lifeCounter = hearts.Length;
        lifeStatus.text = lifeCounter.ToString();
        UpdateHeartIcons();
    }

    // ����� ��� ��������� ������
    public void UpdateLife(int life)
    {
        lifeCounter += life;
        lifeCounter = Mathf.Clamp(lifeCounter, 0, hearts.Length);

        lifeStatus.text = lifeCounter.ToString();
        UpdateHeartIcons();

        if (lifeCounter == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }

    }

    // ���������� ����������� ��������
    private void UpdateHeartIcons()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lifeCounter;
        }
    }

    // ��������� ������
    private void HandleDeath()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        // ������ ���������� ����
    }

    // ���������� ���������
    private void HandleMovement()
    {
        if (moveDirection == 1 && transform.position.y < 3.42f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (moveDirection == -1 && transform.position.y > -3.41f)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    // ������ ��� ���������� ��������� ����� ������
    public void MoveUp(bool isPressed)
    {
        moveDirection = isPressed ? 1 : 0; // ������������� ����������� ��������
    }

    public void Fire()
    {
        if (bulletPrefab != null && spawnBulletPoint != null)
        {
            // ������� ���� � ������� ����� ���������
            GameObject bullet = Instantiate(bulletPrefab, spawnBulletPoint.position, spawnBulletPoint.rotation);

            // ��������� �������� ���� (���� � ��� ���� Rigidbody2D)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.right * 10f; // �������� ����
            }
        }
        else
        {
            Debug.LogError("Bullet prefab or spawn point is not set!");
        }
    }
}

public class FireButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Plane plane; // ����������: ��������� ���� plane

    public void OnPointerDown(PointerEventData eventData)
    {
        if (plane != null)
        {
            plane.Fire();
        }
        else
        {
            Debug.LogError("Plane reference is not set in FireButton!");
        }
    }
}
