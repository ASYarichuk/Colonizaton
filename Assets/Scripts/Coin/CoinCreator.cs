using System.Collections;
using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    [SerializeField] private int _amountCoins = 10;

    [SerializeField] private PositionChecker _positionChecker;

    [SerializeField] private MapSize _mapSize;

    private int _positionCoinY = 2;

    private float _waitUntilCreate = 3f;

    private Vector3 positionCreatedCoin = new Vector3(4, 1, 4);

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var waitUntilCreateCoins = new WaitForSeconds(_waitUntilCreate);

        while (_amountCoins > 0)
        {
            ChangePositionCreatedCoin();
            bool checkCurrentPositionCreatedCoin = _positionChecker.CheckPosition();

            while (checkCurrentPositionCreatedCoin == false)
            {
                ChangePositionCreatedCoin();
                checkCurrentPositionCreatedCoin = _positionChecker.CheckPosition();
            }

            Instantiate(_coinPrefab, positionCreatedCoin, Quaternion.Euler(0, 0, 90));

            _amountCoins--;

            yield return waitUntilCreateCoins;
        }
    }

    private void ChangePositionCreatedCoin()
    {
        positionCreatedCoin = new(Random.Range(_mapSize.GiveMapSizeMinX(), _mapSize.GiveMapSizeMaxX()),
                                _positionCoinY,
                                Random.Range(_mapSize.GiveMapSizeMinZ(), _mapSize.GiveMapSizeMaxZ()));

        _positionChecker.ChangePosition(positionCreatedCoin);
    }
}
