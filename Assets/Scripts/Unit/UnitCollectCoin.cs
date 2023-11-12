using UnityEngine;

public class UnitCollectCoin : MonoBehaviour
{
    [SerializeField] private CollectCoin _collectCoin;

    private CollectCoin _currentCollectionCoin;

    private Transform _currentTarget;

    private Unit _unit;

    private float _speedRotation = 150f;

    private int _amountCoinsInStack = 1;

    private void Awake()
    {
        _unit = GetComponentInParent<Unit>();
    }

    private void Update()
    {
        _currentTarget = _unit.GiveTarget();

        if (_currentCollectionCoin != null)
        {
            _currentCollectionCoin.transform.Rotate(Vector3.right * _speedRotation * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_currentTarget == null)
        {

        }
        else if (other.GetComponent<Coin>() && other.transform.position == _currentTarget.position)
        {
            _currentCollectionCoin = Instantiate(_collectCoin, this.transform.position, Quaternion.Euler(0, 0, 90));
            _currentCollectionCoin.transform.SetParent(this.transform);
            _currentCollectionCoin.transform.position += new Vector3(0, 9, 0);

            Destroy(_currentTarget.gameObject);

            _unit.TakeTarget(null);
        }
        else if (_currentTarget != null && other.transform.position == _currentTarget.position)
        {
            _unit.TakeTarget(null);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.GetComponentInChildren<CollectCoin>() && collision.transform.GetComponent<Base>() && collision.transform.position == _currentTarget.position)
        {
            Destroy(_currentCollectionCoin.gameObject);

            _unit.TakeTarget(null);

            _unit.BroughtCoin(_amountCoinsInStack);
        }
    }
}
