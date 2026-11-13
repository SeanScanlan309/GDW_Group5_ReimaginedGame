using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputAction;
    private Vector2 moveInput;
    private InputAction moveAction;
    private InputAction enterAction;
    [SerializeField] private GameObject selfObject;
    [SerializeField] private Pokemon selfPokemon;

    private int selection = 1;
    public int selectionMax = 4;

    void Awake()
    {
        var playerActoinMap = inputAction.FindActionMap("Player");
        moveAction = playerActoinMap.FindAction("Move");
        enterAction = playerActoinMap.FindAction("Enter");
        moveAction.Enable();
        enterAction.Enable();
    }

    
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        if (moveAction.WasPressedThisFrame())
        {
            if (moveInput.x > 0)
            {
                selection++;
            }
            else if ( moveInput.x < 0)
            {
                selection--;
            }
        }

        if (selection > selectionMax)
        {
            selection = 0;
        }
        else if (selection < 0)
        {
            selection = selectionMax;
        }
        Debug.Log(selection);
        if (enterAction.WasPressedThisFrame())
        {
            selfPokemon.currentHealth--;
        }

    }
}
