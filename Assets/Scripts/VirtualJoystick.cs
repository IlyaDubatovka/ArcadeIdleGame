
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]private Image joystickBackground; // Фон джойстика
    [SerializeField]private Image joystickHandle; // Перемещающаяся часть джойстика
    [SerializeField]private Transform playerTransform; // Ссылка на объект, который нужно перемещать
    [SerializeField]private float speed = 5f; // Скорость движения персонажа
    [SerializeField] private float _rotateSpeed = 5f;

    private Vector2 inputDirection; // Направление движения
    private Vector2 touchPos; // Позиция касания
    

    void Update()
    {
        // Перемещение игрока на основе ввода джойстика
        Vector3 movement = new Vector3(inputDirection.x, 0.0f, inputDirection.y);
        playerTransform.Translate(movement * speed * Time.deltaTime, Space.World);
        if (Vector3.Angle(playerTransform.forward,inputDirection)>0)
        {
            Vector3 newDirection = Vector3.RotateTowards(playerTransform.forward, new Vector3(inputDirection.x,0,inputDirection.y), _rotateSpeed*Time.deltaTime, 90);
            playerTransform.rotation=Quaternion.LookRotation(newDirection);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            Vector2 joystickBackgroundCenter;
            joystickBackgroundCenter.x = joystickBackground.rectTransform.sizeDelta.x/2;
            joystickBackgroundCenter.y = joystickBackground.rectTransform.sizeDelta.y/2;
            joystickPosition.x =(joystickPosition.x-joystickBackgroundCenter.x)/(joystickBackgroundCenter.x);
            joystickPosition.y =(joystickPosition.y-joystickBackgroundCenter.y)/(joystickBackgroundCenter.y);

            inputDirection = new Vector2(joystickPosition.x, joystickPosition.y);

            // Нормализация вектора, если длина больше 1
            if (inputDirection.magnitude > 1f)
            {
                inputDirection.Normalize();
            }

            joystickHandle.rectTransform.anchoredPosition = new Vector2(
                inputDirection.x * (joystickBackground.rectTransform.sizeDelta.x /4),
                inputDirection.y * (joystickBackground.rectTransform.sizeDelta.y /4));
        }
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
    
}