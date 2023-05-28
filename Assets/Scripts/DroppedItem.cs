using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    [SerializeField] private GameObject _droppedItem;
    public void DropItem(int itemCount)
    {
        for (int i = 0; i < itemCount; i++)
        {
            float _randomRange = Random.Range(-0.5f, 0.5f);
            Instantiate(_droppedItem, transform.position + new Vector3(_randomRange, 1f), Quaternion.identity);
        }
    }
}
