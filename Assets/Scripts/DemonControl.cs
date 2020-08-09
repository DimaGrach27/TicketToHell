using UnityEngine;

public class DemonControl : MonoBehaviour
{
    public Animator heroAnimation;
    private void Update()
    {
        transform.Translate(Vector3.right * 2.5f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            heroAnimation.SetTrigger("Teleport");
            //GameObject.FindWithTag("Player").SetActive(false);
            GameControl.death = true;
        }
    }
}