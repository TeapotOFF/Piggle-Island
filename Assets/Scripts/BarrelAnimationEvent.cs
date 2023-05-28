using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAnimationEvent : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Rigidbody2D _rb;
    private Collider2D _collider;

    private void Start()
    {
        _collider = _object.GetComponent<Collider2D>();  
    }

    public void DisableCollider()
    {
        _collider.enabled = false;
    }

    public void DestroyOjbect()
    {
        Destroy(_object);
    }

    public void IgnorePlayer()
    {
        LayerMask layerMask = LayerMask.GetMask("Player");
        _rb.excludeLayers = layerMask;
        _collider.excludeLayers = layerMask;
    }
}
