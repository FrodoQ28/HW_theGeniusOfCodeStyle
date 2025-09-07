using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
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

        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            Bullet newBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.LookRotation(transform.position, direction));

            yield return wait;
        }
    }
}
