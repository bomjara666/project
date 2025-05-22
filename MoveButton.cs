using UnityEngine;
using UnityEngine.EventSystems;

public class PlaneButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("Настройки кнопки")]
    public Plane targetPlane;  // Перетащите сюда объект с Plane
    public int direction;      // 1 для вверх, -1 для вниз

    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetPlane != null)
        {
            targetPlane.moveDirection = direction;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (targetPlane != null)
        {
            targetPlane.moveDirection = 0;
        }
    }
}

// Нет изменений, если нет прямых обращений к Plane.OnTriggerEnter2D или Rocket.OnTriggerEnter2D