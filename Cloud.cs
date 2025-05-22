using UnityEngine;
// ...existing code...
// ��� ���������, ���� ��� ������ ��������� � Plane.OnTriggerEnter2D ��� Rocket.OnTriggerEnter2D
// ...existing code...
public class scrips : MonoBehaviour
{
    [SerializeField]
    private float Speed = 2.5f;
    [SerializeField]
    private float minScale = 0.7f;
    [SerializeField]
    private float maxScale = 1.3f;
    [SerializeField]
    private float minAlpha = 0.3f;  // ����������� ������������ (0 - ��������� ����������)
    [SerializeField]
    private float maxAlpha = 0.8f;    // ������������ ������������ (1 - ��������� ������������)

    private Vector3 moveVector3;
    private float currentSpeed;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // �������� ��������� SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ���� � ������� ���� SpriteRenderer
        if (spriteRenderer != null)
        {
            // ������������� ��������� ������������
            float randomAlpha = Random.Range(minAlpha, maxAlpha);
            Color newColor = spriteRenderer.color;
            newColor.a = randomAlpha;
            spriteRenderer.color = newColor;
        }

        currentSpeed = Random.Range(1, Speed);
        moveVector3 = new Vector3(-currentSpeed, 0);

        float randomScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomScale, randomScale, 1f);
    }

    void Update()
    {
        transform.Translate(moveVector3 * Time.deltaTime);
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}