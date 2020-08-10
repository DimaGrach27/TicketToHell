using UnityEngine;

public class PlayerMeeleAttack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
    }
}
