using UnityEngine;

public class BaseResearch : MonoBehaviour
{
    [SerializeField] private float _radiusResearch = 25f;
    [SerializeField] private CoinsBase _coinBase;

    private void Awake()
    {
        gameObject.GetComponent<SphereCollider>().radius = _radiusResearch;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Coin coin))
        {
            _coinBase.Add(coin);
        }
    }
}
