using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    public event Action TookCoin;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 shift = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            shift.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            shift.y -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            shift.x += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            shift.x -= _speed * Time.deltaTime;
        }
        Move(shift);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            coin.Take();
            TookCoin?.Invoke();
        }
    }

    private void Move(Vector2 shift)
    {
        _rigidbody2D.MovePosition((Vector2)transform.position + shift);
    }
}
