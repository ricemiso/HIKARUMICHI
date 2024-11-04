using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerController controller;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }
    
}
