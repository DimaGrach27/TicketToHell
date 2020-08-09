using UnityEngine;

public class MovePtatform : MonoBehaviour
{
    float speed = 3f;

    bool movingRigth = true;


    public Transform startPoint;
    public Transform endPoint;



    void Update()
    {
        if (transform.position.x < startPoint.position.x)
        {
            movingRigth = true;
        }
        else if(transform.position.x > endPoint.position.x)
        {
            movingRigth = false;
        }

        if (movingRigth == true)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        

    }
}

