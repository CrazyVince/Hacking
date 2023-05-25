using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;

    public float sensitivity = 2;
    public float smoothing = 1.5f;

    public Vector2 targetMouseInput;
    public Vector2 mouseInput;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get smooth velocity.
        targetMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensitivity;
        mouseInput = Vector2.Lerp(mouseInput, targetMouseInput, smoothing);

        character.Rotate(0, mouseInput.x * Time.deltaTime, 0);
        transform.Rotate(-mouseInput.y * Time.deltaTime, 0, 0);
    }
}