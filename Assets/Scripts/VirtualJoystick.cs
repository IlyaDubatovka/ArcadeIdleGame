using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image joystickBackground; // Фон джойстика
    public Image joystickHandle; // Перемещающаяся часть джойстика
    public GameObject player; // Ссылка на объект, который нужно перемещать
    public float speed = 5f; // Скорость движения персонажа

    private Vector2 inputDirection; // Направление движения
    private Vector2 touchPos; // Позиция касания

    void Update()
    {
        // Перемещение игрока на основе ввода джойстика
        Vector3 movement = new Vector3(inputDirection.x, 0.0f, inputDirection.y);
        player.transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Получаем позицию мыши относительно фона джойстика
        touchPos = eventData.position - new Vector2(joystickBackground.rectTransform.position.x, joystickBackground.rectTransform.position.y);

        // Нормализуем направление
        float radius = joystickBackground.rectTransform.sizeDelta.x / 2; // Радиус фона
        inputDirection = new Vector2(touchPos.x / radius, touchPos.y / radius).normalized; // Нормализуется

        // Ограничиваем ручку в пределах фона
        float handleX = Mathf.Clamp(touchPos.x, -radius, radius);
        float handleY = Mathf.Clamp(touchPos.y, -radius, radius);
        
        joystickHandle.rectTransform.anchoredPosition = new Vector2(handleX, handleY);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData); // Начинаем движение
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector2.zero; // Останавливаем движение
        joystickHandle.rectTransform.anchoredPosition = Vector2.zero; // Возвращаем ручку в начальное положение
    }

    private void OnDrawGizmos()
    {
        // Устанавливаем цвет Gizmos (например, красный)
        Gizmos.color = Color.red;

        // Рисуем точку в позиции touchPos относительно позиции joystickBackground
        Vector3 gizmoPosition = joystickBackground.rectTransform.position + (Vector3)touchPos;
        Gizmos.DrawSphere(gizmoPosition, 0.1f); // 0.1f - радиус сферы
    }
}