using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] GameObject basePos;                                                                              
    private Vector2 firstPos;
    private GameObject generateFruits;
    public GameObject[] fruits = new GameObject[5];
    private bool firstFruits;

    void Start()
    {
        firstFruits = true;
        generateFruits = fruits[0];
        FruitsGenerate();
    }

    void Update()
    {

    }

    public void FruitsGenerate()
    {
        firstPos = basePos.transform.position;
        if (!firstFruits)
        {
            int fruitsNum = Random.Range(0, 4);
            generateFruits = fruits[fruitsNum];
        }
        Instantiate(generateFruits, firstPos, Quaternion.identity);

        firstFruits = false;
    }
}
