using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Vector2 _moveDirection;
    private Rigidbody2D rb;
    public float inputHorizontal;
    public int points = 0 ;

// Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);

        InputManager.SetGameControls();

        rb = GetComponent<Rigidbody2D>();

    }

// Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(speed * Time.deltaTime * _moveDirection);

        inputHorizontal = Input.GetAxisRaw(("Horizontal"));

        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }

        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);

        }

    }
    public void SetMovementDirection(Vector2 currentDirection)
    {
        _moveDirection = currentDirection;
    }
}