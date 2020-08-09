using UnityEngine;
using UnityEngine.UI;

public class HelsSystem : MonoBehaviour
{

    public int health;
    public int nemberOfHealth;

    public Image[] lives;

    public Sprite fullLive;
    public Sprite emptyLive;

    private void Start()
    {
        health = 3;
        nemberOfHealth = 3;
    }
    void Update()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (health > nemberOfHealth)
            {
                health = nemberOfHealth;
            }

            if (i < health)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }

            if (i < nemberOfHealth)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }

        if(health == 0)
        {
            GameControl.death = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AddLife")
        {
            Destroy(collision.gameObject);
            nemberOfHealth++;
        }
            

        if (collision.gameObject.tag == "LifePotion")
        {
            Destroy(collision.gameObject);
            health++;
        }
            
    }
}
