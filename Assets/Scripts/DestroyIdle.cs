using UnityEngine;

public class DestroyIdle : MonoBehaviour
{
    Vector2 pos;
    bool isShaiking = false;

    [SerializeField]
    int Health = 2;

    [SerializeField]
    Object destoyIdle;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        if(isShaiking == true)
        {
            transform.position = pos + Random.insideUnitCircle * 0.1f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            isShaiking = true;
            Health--;

            if (Health <= 0)
            {
                ExplodeTheObject();
            }

            Invoke("StopShaiking", 0.5f);
        }

    }

    void StopShaiking()
    {
        isShaiking = false;
        transform.position = pos;
    }

    void ExplodeTheObject()
    {
        GameObject destruct = (GameObject)Instantiate(destoyIdle);
        destruct.transform.position = transform.position;

        Destroy(gameObject);
    }
}
