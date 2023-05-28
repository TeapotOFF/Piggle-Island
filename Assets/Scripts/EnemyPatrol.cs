using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private Transform _enemy;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    private Vector3 _enemyScale;
    private bool _movingLeft;
    private Enemy _enemyScript;

    private void Awake()
    {
        _enemy = GetComponentInChildren<Enemy>().transform;
        _enemyScript = _enemy.GetComponent<Enemy>();
        _enemyScale = _enemy.localScale;
    }

    private void Update()
    {
        if (_enemy)
        {
            CheckDirection();
        } 
        else Destroy(gameObject);
    }

    private void Flip()
    {
        _movingLeft = !_movingLeft;
    }

    private void CheckDirection()
    {
        if (_movingLeft)
        {
            if (_enemy.position.x >= _leftPoint.position.x)
                _enemyScript.MoveInDirection(-1);
            else
                Flip();
        }
        else
        {
            if (_enemy.position.x <= _rightPoint.position.x)
                _enemyScript.MoveInDirection(1);
            else
                Flip();
        }
    }
}
