using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    
    private Rigidbody _bullet;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _bullet = GetComponent<Rigidbody>();
        _waitForSeconds = new WaitForSeconds(_delay);

        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            newBullet.velocity = newBullet.transform.up * _speed;

            yield return _waitForSeconds;
        }
    }
}