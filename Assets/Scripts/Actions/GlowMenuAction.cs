using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlowMenuAction : MonoBehaviour
{
    [SerializeField] AnglePositions _anglePositions;
    [SerializeField] List<Image> _images;
    [SerializeField] int _initialImage = -1;

    private void Awake()
    {
        for (int i = 0; i < _images.Count; ++i)
        {
            _images[i].enabled = false;
        }
        if(_initialImage >= 0 && _initialImage < _images.Count)
        {
            _images[_initialImage].enabled = true;
        }
    }
    public void GlowMenuSelection()
    {
        for(int i = 0; i < _images.Count; ++i)
        {
            _images[i].enabled = false;
        }
        _images[_anglePositions.TargetIndex].enabled = true;
    }
}
