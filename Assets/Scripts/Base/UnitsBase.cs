using System.Collections.Generic;
using UnityEngine;

public class UnitsBase : MonoBehaviour
{
    [SerializeField] private List<Unit> _units = new();
    [SerializeField] private List<Unit> _freeUnits = new();

    [SerializeField] private CoinsBase _coinsBase;

    [SerializeField] private BaseCreator _baseCreator;

    private Unit _unitBuilder;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.TryGetComponent(out Unit unit))
            {
                _units.Add(unit);
            }
        }

        foreach (Unit unit in _units)
        {
            _freeUnits.Add(unit);
        }
    }

    void Update()
    {
        if (_coinsBase.ShowAmount() > 0)
        {
            CollectCoin();
        }

        if (_baseCreator.GiveStatusFlag() && _coinsBase.ShowAvailableMoney() > _baseCreator.GiveAmountMoneyForCreateBase())
        {
            SendBuilder();
        }

        if (_unitBuilder!= null &&_unitBuilder.isReadyBuild())
        {
            BuildNewBase();
        }
    }

    private void CollectCoin()
    {
        if (_freeUnits.Count > 0)
        {
            Unit currentUnit = _freeUnits[0];
            _freeUnits.Remove(currentUnit);

            Coin targetCoin = _coinsBase.TakeFirstCoin();

            currentUnit.TakeTarget(targetCoin.transform);
        }
    }

    private void SendBuilder()
    {
        if (_freeUnits.Count > 0)
        {
            Unit unit = _freeUnits[0];
            _freeUnits.Remove(unit);
            _units.Remove(unit);

            _unitBuilder = unit;
            unit.ChangeStatusUnit(true);

            Transform target = _baseCreator.GiveTarget();

            unit.TakeTarget(target);

            _baseCreator.SpendCoinsOnBuildingNewBase();
        }
    }

    private void BuildNewBase()
    {
        _baseCreator.BuildBase();
        _unitBuilder.transform.SetParent(_baseCreator.GiveCoordinateNewBase());
    }

    public void AddFreeUnit(Unit unit)
    {
        if (_freeUnits.Contains(unit) == false && _units.Contains(unit))
        {
            _freeUnits.Add(unit);
        }
    }

    public void AddNewUnit(Unit unit)
    {
        _units.Add(unit);
    }
}
