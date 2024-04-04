using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualDisplayClickHandler : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler, IDragHandler,
      IPointerClickHandler, ISubmitHandler,
        IMoveHandler, IScrollHandler,
        IPointerDownHandler, IPointerUpHandler,
        IPointerEnterHandler, IPointerExitHandler,
        ISelectHandler, IDeselectHandler
{
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject upperDisplayRoot;

    private GameObject[] displaychilds;
    public void OnBeginDrag(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.beginDragHandler);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.deselectHandler);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.dragHandler);
            Debug.Log(eventData.position);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.endDragHandler);
        }
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.initializePotentialDrag);
        }
    }

    public void OnMove(AxisEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.moveHandler);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.pointerClickHandler);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.pointerDownHandler);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.pointerEnterHandler);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child,
                           eventData, ExecuteEvents.pointerExitHandler
                                      );
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child,
            eventData, ExecuteEvents.pointerUpHandler
            );
        }
    }

    public void OnScroll(PointerEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.scrollHandler);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.selectHandler);
        }
    }

    public void OnSubmit(BaseEventData eventData)
    {
        foreach (GameObject child in displaychilds)
        {
            ExecuteEvents.ExecuteHierarchy(child, eventData, ExecuteEvents.submitHandler);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform[] allChildren = display.GetComponentsInChildren<Transform>();
        displaychilds = new GameObject[allChildren.Length];
        for (int i = 0; i < allChildren.Length; i++)
        {
            displaychilds[i] = allChildren[i].gameObject;
        }
    }
}
