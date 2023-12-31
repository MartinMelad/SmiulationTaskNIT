using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Extends MonoBehaviour to support invoking 
/// one integer argument UnityEvents
/// </summary>
public class ObjectEventInvoker : MonoBehaviour
{
    protected Dictionary<EventName, UnityEvent<GameObject>> unityEvents =
        new Dictionary<EventName, UnityEvent<GameObject>>();

    /// <summary>
    /// Adds the given listener for the given event name
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="listener">listener</param>
    public void AddListener(EventName eventName, UnityAction<GameObject> listener)
    {
        // only add listeners for supported events
        if (unityEvents.ContainsKey(eventName))
        {
            unityEvents[eventName].AddListener(listener);
        }
    }
}