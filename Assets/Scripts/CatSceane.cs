using UnityEngine;

public class CatSceane : MonoBehaviour
{

    void Start()
    {
        Invoke("FinishCatSceane", 5);
    }

    void FinishCatSceane()
    {
        GameControl.finishLevel = true;
    }

}
