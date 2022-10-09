using UnityEngine;

public class Timer : MonoBehaviour
{
    float StartTime = 0.0f;
    private void Update()
    {
        StartTime += Time.deltaTime;
    }
}
