using UnityEngine;
using UnityEngine.UI;

public class HaronQustion : MonoBehaviour
{
    public GameObject qustion;
    public GameObject neVerno;
    public GameObject verno;
    public GameObject text;

    public static bool VerniiOtvet = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            qustion.SetActive(false);
    }
    public void NotVerno()
    {
        text.SetActive(false);
        neVerno.SetActive(true);
    }

    public void Verno()
    {
        VerniiOtvet = true;
        neVerno.SetActive(false);
        text.SetActive(false);
        verno.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !VerniiOtvet)
        {
            qustion.SetActive(true);
        }
    }
}
