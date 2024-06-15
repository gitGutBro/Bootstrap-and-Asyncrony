using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Calculator
{
    public async void StartCalculator(CancellationToken cancellationToken)
    {
        while (true)
        {
            float result = await Calculate(Tools.Random(1, 10), Tools.Random(20, 30));
            Debug.Log(result);
        }
    }

    private async UniTask<float> Calculate(float leftOperand, float rightOperand) => 
        await UniTask.FromResult(leftOperand + rightOperand);
}