using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Calculator
{
    public async UniTask StartCalculatorAsync(CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested == false)
        {
            Debug.Log(cancellationToken.GetHashCode());
            float result = Calculate(Tools.Random(1, 10), Tools.Random(20, 30));
            Debug.Log(result);

            await UniTask.Yield();
        }
    }

    private float Calculate(float leftOperand, float rightOperand) => 
        leftOperand + rightOperand;
}