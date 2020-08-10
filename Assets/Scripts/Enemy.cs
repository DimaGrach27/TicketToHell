using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int Health = 3;
    public Animator anim;
    public AudioSource m_MyAudioSource;
    public LayerMask whatIsPlayer;
    public GameObject fireBall;     //Публично выбираем игровой обьект
    public Transform castPoint;     //Публично выбираем трансформ игрового обьекта
    public bool isCastBall = false;


    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
            Die();
    }

    void Die()
    {
        m_MyAudioSource.Play();
        anim.SetTrigger("Boom");
        Destroy(gameObject, 0.9f);
    }
}
