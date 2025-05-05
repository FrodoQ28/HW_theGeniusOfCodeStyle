using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform[] _places;
    [SerializeField] private float _speed;

    private int _currentPlace = 0;

    public void Update()
    {
        if (_places != null)
        {
            if (transform.position == _places[_currentPlace].position)
                _currentPlace = _currentPlace++ % _places.Length;

            transform.position = Vector3.MoveTowards(transform.position, _places[_currentPlace].position, _speed * Time.deltaTime);
        }
    }
}