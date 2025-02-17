using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    [SerializeField] protected Vector3 moveDirection;
    public Vector3 MoveDirection { get { return moveDirection; } }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        GetInput();
    }

    protected virtual void GetInput()
    {
        this.onFiring = Input.GetKey(KeyCode.Return) ? 1f : 0f;
        float horizontal = Input.GetAxis("Horizontal"); // A, D or Left Arrow, Right Arrow
        float vertical = Input.GetAxis("Vertical"); // W, S or Up Arrow, Down Arrow
        moveDirection = new Vector3(horizontal, vertical, 0f).normalized;
    }
}
