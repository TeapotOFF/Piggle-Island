using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected int _damage;
    [SerializeField] protected Animator _animator;
    public void TakeDamage(int damage)
    { 
        _health -= damage;
        if (_health == 0) DestroyObject();
    }
     
    protected void DestroyObject()
    {
        DisableMovement();
        _animator.SetTrigger("isDestroy");
    }

    private void DisableMovement()
    {
        _speed = 0;
        _jumpForce = 0;
    }

    public virtual void MoveInDirection(int _direction) { }
    public float GetSpeed() { return _speed; }
}
