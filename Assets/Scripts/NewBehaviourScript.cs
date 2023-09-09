using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _hitEffect.Play();
    }

}
