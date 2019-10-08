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

	// save lists of invokers and listeners
    static List<HintPoint> addUndecidedLadderInvokers = new List<HintPoint>();
    static List<UnityAction<Vector3, Vector3>> addUndecidedLadderListeners = new List<UnityAction<Vector3, Vector3>>();

    static List<Ladder> addShowHintPointsInvokers = new List<Ladder>();
    static List<UnityAction<int>> addShowHintPointsListeners = new List<UnityAction<int>>();

    #endregion

    #region Public methods

    // Adds the given script as an invoker
    public static void AddUndecidedLadderInvoker(HintPoint invoker)
    {
        // add invoker to list and add all listeners to invoker
        addUndecidedLadderInvokers.Add(invoker);
        foreach (UnityAction<Vector3, Vector3> listener in addUndecidedLadderListeners)
        {
            invoker.AddUndecidedLadderListener(listener);
        }
    }

    // Adds the given event handler as a listener
    public static void AddUndecidedLadderListener(UnityAction<Vector3, Vector3> handler)
    {
        addUndecidedLadderListeners.Add(handler);
        foreach (HintPoint hintPoint in addUndecidedLadderInvokers)
        {
            hintPoint.AddUndecidedLadderListener(handler);
        }
    }

    public static void AddShowHintPointsInvoker(Ladder invoker)
    {
        // add invoker to list and add all listeners to invoker
        addShowHintPointsInvokers.Add(invoker);
        foreach (UnityAction<int> listener in addShowHintPointsListeners)
        {
            invoker.AddShowHintPointsListener(listener);
        }
    }

    // Adds the given event handler as a listener
    public static void AddShowHintPointsListener(UnityAction<int> handler)
    {
        addShowHintPointsListeners.Add(handler);
        foreach (Ladder ladder in addShowHintPointsInvokers)
        {
            ladder.AddShowHintPointsListener(handler);
        }
    }

    #endregion
}
