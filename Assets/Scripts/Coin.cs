using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float _maxX;
    [SerializeField] private float _maxY;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Take()
    {
        Vector2 newPosition = new Vector2(Random.Range(-_maxX, _maxX), Random.Range(-_maxY, _maxY));
        _rigidbody2D.MovePosition(newPosition);
    }
}
