using System.Collections;
using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    [SerializeField] private int _amountCoins = 10;

    [SerializeField] private MapSize _mapSize;

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
            Instantiate(_coinPrefab, positionCreatedCoin, Quaternion.Euler(0, 0, 90));

            _amountCoins--;

            yield return waitUntilCreateCoins;
        }
    }
}
