using UnityEngine;
// ...existing code...
// ��� ���������, ���� ��� ������ ��������� � Plane.OnTriggerEnter2D ��� Rocket.OnTriggerEnter2D
// ...existing code...
using UnityEngine.EventSystems;

public class FireButtonHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Plane plane;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (plane != null)
        {
            plane.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            Debug.LogError("Plane reference is not set in FireButtonHandler!");
        }
    }
}
