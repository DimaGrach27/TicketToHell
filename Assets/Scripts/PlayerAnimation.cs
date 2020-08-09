using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*if(GameControl.death)
            anim.SetTrigger("Teleport");
        if(GameControl.finishLevel)
            anim.SetTrigger("Teleport");*/
    }
}
