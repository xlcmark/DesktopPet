using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniVRM10;

public class EventManager : MonoBehaviour
{
    public static Action<ExpressionKey> OnExpressionChange;
    public static void ExpressionChanged(ExpressionKey expressionKey)
    {
        OnExpressionChange?.Invoke(expressionKey);
    }
}
