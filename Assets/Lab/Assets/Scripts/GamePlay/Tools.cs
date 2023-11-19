using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : ObjectEventInvoker
{
    private void Start()
    {
        unityEvents.Add(EventName.SetActiveTool, new SetActiveToolEvent());
        EventManager.AddInvoker(EventName.SetActiveTool, this);
        GetComponent<Outline>().enabled = false;
    }
    private void OnMouseDown()
    {
        unityEvents[EventName.SetActiveTool].Invoke(gameObject);

    }
}
