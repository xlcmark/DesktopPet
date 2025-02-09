using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UniVRM10;

public class VrmExpressionChanger : MonoBehaviour
{
    private Vrm10Instance instance;
    private ExpressionKey currentExpression;
    private ExpressionKey targetExpression;
    private Coroutine coroutine;

    public float transitionTime = .15f;
    void Start()
    {
        instance = GetComponent<Vrm10Instance>();
        EventManager.OnExpressionChange += ChangeExpression;
        
    }
    public void ChangeExpression(ExpressionKey _key)
    {
        if(coroutine!=null)
        {
            StopCoroutine(coroutine);
        }
        coroutine= StartCoroutine(ExpressionDuration(_key,transitionTime));
    }
    private IEnumerator ExpressionDuration(ExpressionKey _nextExpression,float _transitionTime)
    {   
        //reset
        instance.Runtime.Expression.SetWeight(currentExpression,0);
        instance.Runtime.Expression.SetWeight(targetExpression,0);

        currentExpression=targetExpression;
        targetExpression=_nextExpression;

        float _time=0;

        while(_time<_transitionTime)
        {
            _time+=Time.deltaTime;
            instance.Runtime.Expression.SetWeight(currentExpression,Mathf.Lerp(1,0,_time/_transitionTime));
            instance.Runtime.Expression.SetWeight(targetExpression,Mathf.Lerp(0,1,_time/_transitionTime));
            yield return null;
        }
        instance.Runtime.Expression.SetWeight(currentExpression,0);
        instance.Runtime.Expression.SetWeight(_nextExpression,1);

    }
    
}
