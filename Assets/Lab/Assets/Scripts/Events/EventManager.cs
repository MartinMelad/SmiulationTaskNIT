using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages connections between event listeners and event invokers
/// </summary>
public static class EventManager
{
    #region Fields

    static Dictionary<EventName, List<ObjectEventInvoker>> invokers =
        new Dictionary<EventName, List<ObjectEventInvoker>>();
    static Dictionary<EventName, List<UnityAction<GameObject>>> listeners =
        new Dictionary<EventName, List<UnityAction<GameObject>>>();

    #endregion

    #region Public methods

    /// <summary>
    /// Initializes the event manager
    /// </summary>
    public static void Initialize()
    {
        // create empty lists for all the dictionary entries
        foreach (EventName name in Enum.GetValues(typeof(EventName)))
        {
            if (!invokers.ContainsKey(name))
            {
                invokers.Add(name, new List<ObjectEventInvoker>());
                listeners.Add(name, new List<UnityAction<GameObject>>());
            }
            else
            {
                invokers[name].Clear();
                listeners[name].Clear();
            }
        }
    }

    /// <summary>
    /// Adds the given invoker for the given event name
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="invoker">invoker</param>
    public static void AddInvoker(EventName eventName, ObjectEventInvoker invoker)
    {
        // add listeners to new invoker and add new invoker to dictionary
        foreach (UnityAction<GameObject> listener in listeners[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        invokers[eventName].Add(invoker);
    }

    /// <summary>
    /// Adds the given listener for the given event name
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="listener">listener</param>
    public static void AddListener(EventName eventName, UnityAction<GameObject> listener)
    {
        // add as listener to all invokers and add new listener to dictionary
        foreach (ObjectEventInvoker invoker in invokers[eventName])
        {
            invoker.AddListener(eventName, listener);
        }
        listeners[eventName].Add(listener);
    }

    /// <summary>
    /// Removes the given invoker for the given event name
    /// </summary>
    /// <param name="eventName">event name</param>
    /// <param name="invoker">invoker</param>
    public static void RemoveInvoker(EventName eventName, ObjectEventInvoker invoker)
    {
        // remove invoker from dictionary
        invokers[eventName].Remove(invoker);
    }

    #endregion
}
