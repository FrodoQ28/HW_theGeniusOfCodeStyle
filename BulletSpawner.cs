using UnityEngine;

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _placesParent;
    [SerializeField] private Transform[] _places;
    [SerializeField] private float _speed;

    private int _currentPlace = 0;
    private int _minArrowLength = 1;

    private void Awake()
    {
        if (_places == null)
        {
            _places = new Transform[_minArrowLength];
            _places[0] = transform;
        }
    }

    public void Update()
    {
        if (transform.position == _places[_currentPlace].position)
        {
            _currentPlace = ++_currentPlace % _places.Length;
            TurnToNextPlace();
        }

        transform.position = Vector3.MoveTowards(transform.position, _places[_currentPlace].position, _speed * Time.deltaTime);
    }

    private void TurnToNextPlace()
    {
        transform.forward = _places[_currentPlace].position - transform.position;
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int placeCount = _placesParent.transform.childCount;
        _places = new Transform[placeCount];

        for (int i = 0; i < placeCount; i++)
            _places[i] = _placesParent.transform.GetChild(i);
    }
#endif
}
