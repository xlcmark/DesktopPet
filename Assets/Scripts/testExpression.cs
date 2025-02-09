using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniVRM10;

public class testExpression : MonoBehaviour
{
    Vrm10Instance instance;
    // Start is called before the first frame update
    void Start()
    {
        instance=GetComponent<Vrm10Instance>();
        //instance.Runtime.Expression.SetWeight(ExpressionKey.CreateCustom("123"), 1);
        instance.Runtime.Expression.SetWeight(ExpressionKey.Happy, 1);
    }

    
}
