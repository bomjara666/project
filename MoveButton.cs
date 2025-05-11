using UnityEngine;
using UnityEngine.EventSystems;

public class PlaneButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("��������� ������")]
    public Plane targetPlane;  // ���������� ���� ������ � Plane
    public int direction;      // 1 ��� �����, -1 ��� ����

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