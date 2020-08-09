using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
