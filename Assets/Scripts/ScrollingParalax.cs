using UnityEngine;

public class ScrollingParalax : MonoBehaviour
{
    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 5;
    private int leftIndex;
    private int rigtIndex;

    public float backgroundSize;
    public float parallaxSpeed;

    private float lastCameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;

        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rigtIndex = layers.Length - 1;
    }

    private void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
        transform.position += Vector3.right * (deltaX * parallaxSpeed);
        lastCameraX = cameraTransform.position.x;
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) ScrollLeft();
        if (cameraTransform.position.x > (layers[rigtIndex].transform.position.x - viewZone)) ScrollRight();

    }

    private void ScrollLeft()
    {
        int lastRight = rigtIndex;
        layers[rigtIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rigtIndex;
        rigtIndex--;

        if (rigtIndex < 0)
        {
            rigtIndex = layers.Length - 1;
        }
    }
    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rigtIndex].position.x + backgroundSize);
        rigtIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
