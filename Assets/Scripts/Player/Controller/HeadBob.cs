// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public float bobSpeed = 1f;
    public float bobAmount = 0.05f;
    public float bobHorizontalAmount = 0.05f; 

    private Vector3 originalPosition;
    private float timer = 0f;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        float waveSlice = Mathf.Sin(timer);
        float horizontalSlice = Mathf.Cos(timer);
        Vector3 newPosition = originalPosition;

        if (waveSlice != 0)
        {
            float translateChange = waveSlice * bobAmount;
            newPosition.y = originalPosition.y + translateChange;
        }

        if (horizontalSlice != 0) 
        {
            float horizontalChange = horizontalSlice * bobHorizontalAmount;
            newPosition.x = originalPosition.x + horizontalChange;
        }

        transform.localPosition = newPosition;
        timer += bobSpeed * Time.deltaTime;

        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }
    }
}
