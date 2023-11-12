using UnityEngine;

public class UnitCreator : MonoBehaviour
{
    [SerializeField] private CoinsBase _coinsBase;

    [SerializeField] private UnitsBase _unitsBase;

    [SerializeField] private BaseCreator _baseCreator;

    [SerializeField] private Unit _unitPrefab;

    [SerializeField] private Transform _startPosition;

    private int _amountMoneyForCreateUnit = 3;

    private void Update()
    {
        if (_baseCreator.GiveStatusFlag() == false)
        {
            CreateUnit();
        }
    }

    private void CreateUnit()
    {
        if(_coinsBase.ShowAvailableMoney() >= _amountMoneyForCreateUnit)
        {
            _coinsBase.DeleteAvailableMoney(_amountMoneyForCreateUnit);

            Vector3 startPositionCreateUnit = new (_unitsBase.transform.position.x, 0, _unitsBase.transform.position.z);

            Unit newUnit = Instantiate(_unitPrefab, startPositionCreateUnit, Quaternion.identity, transform);

            newUnit.TakeTarget(_startPosition);

            _unitsBase.AddNewUnit(newUnit);
        }
    }
}
