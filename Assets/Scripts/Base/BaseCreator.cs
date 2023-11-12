using UnityEngine;

public class BaseCreator : MonoBehaviour
{
    [SerializeField] private GameObject _flagNewBase;

    [SerializeField] private GameObject _ground;

    [SerializeField] private MapSize _mapSize;

    [SerializeField] private CoinsBase _coinsBase;

    [SerializeField] private Base _basePrefab;

    private int _amountMoneyForCreateBase = 5;

    private bool _statusFlag = false;

    private GameObject _flag;

    private Vector3 _position;

    private int _distanceFromConstructionPoint = 15;

    private Base _newBase;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (_ground.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _position = hit.point;

                _position = CheckPosition(_position);

                if (_statusFlag)
                {
                    _flag.transform.position = _position + Vector3.up;
                }
                else
                {
                    _flag = Instantiate(_flagNewBase, _position + Vector3.up, Quaternion.identity);
                    _statusFlag = true;
                }
            }
        }
    }

    public Transform GiveTarget()
    {
        return _flag.transform;
    }

    public bool GiveStatusFlag()
    {
        return _statusFlag;
    }

    public int GiveAmountMoneyForCreateBase()
    {
        return _amountMoneyForCreateBase;
    }

    private Vector3 CheckPosition(Vector3 position)
    {
        if (position.x < _mapSize.GiveMapSizeMinX())
        {
            position.x = _mapSize.GiveMapSizeMinX();
        }

        if (position.x > _mapSize.GiveMapSizeMaxX())
        {
            position.x = _mapSize.GiveMapSizeMaxX();
        }

        if (position.z < _mapSize.GiveMapSizeMinZ())
        {
            position.z = _mapSize.GiveMapSizeMinZ();
        }

        if (position.z > _mapSize.GiveMapSizeMaxZ())
        {
            position.z = _mapSize.GiveMapSizeMaxZ();
        }

        return new Vector3(position.x, position.y, position.z);
    }

    public void BuildBase()
    {
        if (_coinsBase.ShowAvailableMoney() >= _amountMoneyForCreateBase && _statusFlag)
        {
            Destroy(_flag);

            _statusFlag = false;

            Vector3 positionBuildingBase = new Vector3(_position.x + _distanceFromConstructionPoint, _position.y, _position.z + _distanceFromConstructionPoint);

            _newBase = Instantiate(_basePrefab, positionBuildingBase, Quaternion.identity);
        }
    }

    public void SpendCoinsOnBuildingNewBase()
    {
        _coinsBase.DeleteAvailableMoney(_amountMoneyForCreateBase);
    }

    public Transform GiveCoordinateNewBase()
    {
        if (_newBase != null)
        {
            return _newBase.transform;
        }
        else
        {
            return null;
        }
    }
}
