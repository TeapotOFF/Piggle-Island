using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayAnimation()
    {
        _animator.SetTrigger("isJumped");
    }
}
