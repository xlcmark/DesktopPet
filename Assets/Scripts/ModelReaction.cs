using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModelReaction : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void OnMouseDown()
    {
        anim.SetTrigger("react");
    }
}
