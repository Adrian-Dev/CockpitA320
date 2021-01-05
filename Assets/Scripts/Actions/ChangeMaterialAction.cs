using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialAction : MonoBehaviour
{
    [SerializeField] Renderer _renderer;

    public void ChangeMaterial(Material _material)
    {
        _renderer.material = _material;
    }
}
