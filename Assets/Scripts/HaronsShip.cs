using System.Net.Sockets;
using UnityEngine;

public class HaronsShip : MonoBehaviour
{
    bool playerInShip = false;
    bool move = false;
    public GameObject haron1;
    public GameObject haron2;
    public Transform endPoint;


    void Update()
    {
        if (move && playerInShip && (transform.position.x < endPoint.position.x))
            ///  transform.Translate(Vector3.right * 2f * Time.deltaTime, endPoint);
            transform.Translate(Vector2.right * 2f * Time.deltaTime);

        if (HaronQustion.VerniiOtvet)
        {
            haron1.SetActive(false);
            haron2.SetActive(true);
            HaronQustion.VerniiOtvet = false;
            move = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInShip = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInShip = false;
        }
    }
}
