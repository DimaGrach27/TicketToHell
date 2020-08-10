using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public bool isFalling = false;

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            isFalling = true;
            Destroy(gameObject, 2f);
        }
            
    }

    void Update()
    {
        Fall();
    }

    void Fall()
    {
       if(isFalling == true)
            transform.Translate(Vector2.down * 6f * Time.deltaTime);
    }
}
