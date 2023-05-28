using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedObjects : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private int _droppedItemCount;
    [SerializeField] private Animator _animator;

    private DroppedItem _droppedItem;

    private void Start()
    {
        _droppedItem = GetComponent<DroppedItem>();
    }
    void Update()
    {
        if (_health == 0) 
        { 
            _health = -1;
            _animator.SetTrigger("isDestroy");
            _droppedItem.DropItem(_droppedItemCount); 
        }
    }

    public void TakeDamage(int damage) 
    {
        _health -= damage;
        if (_health != 0)
            _animator.SetTrigger("isDamage");
    }
}
