using UnityEngine;

public class UnitMover : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _speedRotation;

    private Transform _currentTarget;

    private string _nameAnimationWalk = "IsWalking";

    private Animator _animator;

    private Unit _unit;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _unit = GetComponent<Unit>();
    }

    private void Update()
    {
        _currentTarget = _unit.GiveTarget();

        if (_currentTarget != null)
        {
            MoveTo(_currentTarget);
        }
        else
        {
            StopMove();
        }
    }

    private void MoveTo(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(target.position.x, transform.position.y, target.position.z),
                    _speed * Time.deltaTime);

        Vector3 directionRotete = new Vector3(target.position.x - transform.position.x,
                                        transform.position.y,
                                        target.position.z - transform.position.z);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionRotete), Time.deltaTime * _speedRotation);

        _animator.SetBool(_nameAnimationWalk, true);
    }

    private void StopMove()
    {
        transform.SetPositionAndRotation(transform.position, Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * _speedRotation));

        _animator.SetBool(_nameAnimationWalk, false);
    }
}
