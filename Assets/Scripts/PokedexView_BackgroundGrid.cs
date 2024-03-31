using MagicTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokedexView_BackgroundGrid : MonoBehaviour
{
    [SerializeField] private uint loopDuration;
    [SerializeField] private float targetPosX;
    // Start is called before the first frame update
    void Start()
    {
        transform.TweenPositionX(targetPosX, loopDuration).SetLoops(-1, LoopType.Restart).Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
