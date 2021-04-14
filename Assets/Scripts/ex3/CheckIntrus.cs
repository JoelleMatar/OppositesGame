using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIntrus : MonoBehaviour
{
    public static bool intrus1 = false, intrus2 = false, intrus3 = false;

    [SerializeField]
    private GameObject checkedShort, checkedSingle, checkedLight;
    [SerializeField]
    private GameObject shortIntrus, singleIntrus, lightIntrus;

    // Start is called before the first frame update
    void Start()
    {
        checkedShort.SetActive(false);
        checkedLight.SetActive(false);
        checkedSingle.SetActive(false);
        shortIntrus.SetActive(true);
        singleIntrus.SetActive(true);
        lightIntrus.SetActive(true);
        intrus1 = false;
        intrus2 = false;
        intrus3 = false;
    }

    public void checkShort()
    {
        checkedShort.SetActive(true);
        shortIntrus.SetActive(false);
        intrus1 = true;
    }

    public void checkSingle()
    {
        checkedSingle.SetActive(true);
        singleIntrus.SetActive(false);
        intrus2 = true;
    }

    public void checkLight()
    {
        checkedLight.SetActive(true);
        lightIntrus.SetActive(false);
        intrus3 = true;
    }



    //// Update is called once per frame
    //void Update()
    //{

    //}
}
