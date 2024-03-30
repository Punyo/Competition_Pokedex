using MagicTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokedexBoot : MonoBehaviour
{
    [SerializeField] private float pokedexPosYBoot;
    [SerializeField] private float pokedexPosYBootDuration;
    private float InitialPokedexPosY { get; set; }

    [SerializeField] private Camera upperDisplayCamera;
    [SerializeField] private Camera lowerDisplayCamera;
    [SerializeField] private float cameraSizeChangeDuration;

    [SerializeField] private Image pokedexMask;
    [SerializeField] private float maskAlphaDuration;

    [SerializeField]private float delayBeforeMaskFade;
    // Start is called before the first frame update
    void Awake()
    {
        InitialPokedexPosY = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBootSequence()
    {
        Sequence sequence = Sequence.Create();
        sequence.Append(transform.TweenPositionY(pokedexPosYBoot, pokedexPosYBootDuration));
        sequence.AppendCallback(() =>
        {
            pokedexMask.TweenColorAlpha(1, maskAlphaDuration).SetDelay(delayBeforeMaskFade).Play();
            Tween.FromTo(x => upperDisplayCamera.orthographicSize = x, upperDisplayCamera.orthographicSize, 0, cameraSizeChangeDuration).SetDelay(delayBeforeMaskFade).Play();
            Tween.FromTo(x => lowerDisplayCamera.orthographicSize = x, lowerDisplayCamera.orthographicSize, 0, cameraSizeChangeDuration).SetDelay(delayBeforeMaskFade).Play();
        });
    }
}
