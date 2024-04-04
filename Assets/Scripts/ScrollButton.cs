using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollButton : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float scrollSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  
    public void OnPointerDown(PointerEventData eventData)
    {
        scrollRect.verticalNormalizedPosition +=scrollSpeed;
    }
}
