using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _speedRotation = 210f;

    private void Update()
    {
        transform.Rotate(Vector3.right * _speedRotation * Time.deltaTime);
    }
}
