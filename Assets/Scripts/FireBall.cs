using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public SpriteRenderer spriterenderer;

    void FixedUpdate()
    {
        rigidbody2d.velocity = transform.right * 5f;
    }

    void Update()
    {
        Destroy(gameObject, 5f);
       // spriterenderer.color.a -= 0.2f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(1);
        }
        if (col.gameObject.name.Equals("Enemy"))
        {
            Destroy(gameObject);
        } 
    }
}
