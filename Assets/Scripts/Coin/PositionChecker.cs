using UnityEngine;

public class PositionChecker : MonoBehaviour
{
    [SerializeField] CoinCreator _coincreator;

    private bool isFreePosition = true;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.GetComponent<Base>())
        {
            isFreePosition = false;
        }
        else
        {
            isFreePosition = true;
        }
    }

    public void ChangePosition(Vector3 positionToCheck)
    {
        transform.position = positionToCheck;
    }

    public bool CheckPosition()
    {
        return isFreePosition;
    }
}
