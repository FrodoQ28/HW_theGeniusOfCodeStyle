using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.linearVelocity = transform.up * _speed * Time.deltaTime;
    }
}
