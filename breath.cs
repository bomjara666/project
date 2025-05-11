using UnityEngine;

public class FlyingCatBreathing : MonoBehaviour
{
    [Header("��������� �������")]
    [SerializeField] private float breathSpeed = 0.8f; // �������� �������
    [SerializeField] private float inhaleScale = 1.1f; // ������ �� �����
    [SerializeField] private float exhaleScale = 0.95f; // ������ �� ������
    [SerializeField] private float tailWagSpeed = 3f; // �������� �������� ������
    [SerializeField] private Transform tailBone; // ������ �� ����� (���� ����)

    private Vector3 originalScale;
    private float timer;
    private bool isInhaling = true;

    void Start()
    {
        originalScale = transform.localScale;
        timer = Random.Range(0f, 2f); // ��������� ���� �������
    }

    void Update()
    {
        // �������� ������� (���������)
        timer += Time.deltaTime * breathSpeed;
        float breathFactor = Mathf.PingPong(timer, 1f);
        transform.localScale = originalScale * Mathf.Lerp(exhaleScale, inhaleScale, breathFactor);

        // �������� ������ (���� ����)
        if (tailBone != null)
        {
            float wagAngle = Mathf.Sin(Time.time * tailWagSpeed) * 15f; // +/-15 ��������
            tailBone.localRotation = Quaternion.Euler(0, 0, wagAngle);
        }
    }
}