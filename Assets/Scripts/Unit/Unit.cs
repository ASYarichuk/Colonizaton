using UnityEngine;

public class Unit : MonoBehaviour
{
    private CoinsBase _coinsBase;

    private UnitsBase _unitBase;

    private Transform _target;

    private bool _isBuilder = false;

    private bool _isReadyBuild = false;

    private void Awake()
    {
        _coinsBase = GetComponentInParent<CoinsBase>();
        _unitBase = GetComponentInParent<UnitsBase>();
    }

    private void Update()
    {
        if (_target == null && transform.GetComponentInChildren<CollectCoin>())
        {
            _target = _coinsBase.transform;
        }

        if (_target == null && !transform.GetComponentInChildren<CollectCoin>())
        {
            _unitBase.AddFreeUnit(this);
        }

        if (_target == null && _isBuilder == true)
        {
            _isReadyBuild = true;
        }
    }

    public void TakeTarget(Transform target)
    {
        if (target != null && target.TryGetComponent<Coin>(out Coin coin))
        {
            _target = target;
            _coinsBase.Delete(coin);
        }
        else if (target != null)
        {
            _target = target;
        }
        else
        {
            _target = null;
        }
    }

    public Transform GiveTarget()
    {
        return _target;
    }

    public void BroughtCoin(int amountBroughtCoins)
    {
        _coinsBase.AddAvailableMoney(amountBroughtCoins);
    }

    public bool isReadyBuild()
    {
        return _isReadyBuild;
    }

    public void ChangeStatusUnit(bool currentStatus)
    {
        _isBuilder = currentStatus;
    }
}
