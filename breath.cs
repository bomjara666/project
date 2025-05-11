using UnityEngine;

public class FlyingCatBreathing : MonoBehaviour
{
    [Header("Настройки дыхания")]
    [SerializeField] private float breathSpeed = 0.8f; // Скорость дыхания
    [SerializeField] private float inhaleScale = 1.1f; // Размер на вдохе
    [SerializeField] private float exhaleScale = 0.95f; // Размер на выдохе
    [SerializeField] private float tailWagSpeed = 3f; // Скорость движения хвоста
    [SerializeField] private Transform tailBone; // Ссылка на хвост (если есть)

    private Vector3 originalScale;
    private float timer;
    private bool isInhaling = true;

    void Start()
    {
        originalScale = transform.localScale;
        timer = Random.Range(0f, 2f); // Случайная фаза дыхания
    }

    void Update()
    {
        // Анимация дыхания (пульсация)
        timer += Time.deltaTime * breathSpeed;
        float breathFactor = Mathf.PingPong(timer, 1f);
        transform.localScale = originalScale * Mathf.Lerp(exhaleScale, inhaleScale, breathFactor);

        // Анимация хвоста (если есть)
        if (tailBone != null)
        {
            float wagAngle = Mathf.Sin(Time.time * tailWagSpeed) * 15f; // +/-15 градусов
            tailBone.localRotation = Quaternion.Euler(0, 0, wagAngle);
        }
    }
}