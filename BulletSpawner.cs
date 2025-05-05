using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(CreatingBullet());
    }

    private IEnumerator CreatingBullet()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        bool isWork = true;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            GameObject newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

            if (newBullet.TryGetComponent(out Rigidbody bulletRigidbody))
            {
                bulletRigidbody.transform.up = direction;
                bulletRigidbody.velocity = direction * _speed * Time.deltaTime;
            }

            yield return wait;
        }
    }
}