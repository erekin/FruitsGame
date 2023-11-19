using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Transform basePos;
    [SerializeField] private GameObject[] fruits;
  
    private bool firstFruits;
    private GameObject generateFruits;
    private int MaxFruitsNo;

    void Start()
    {
        firstFruits = true;
        generateFruits = fruits[0];
        MaxFruitsNo = fruits.Length;
        FruitsGenerate();
    }

    public void FruitsGenerate()
    {
        if (!firstFruits)
        {
            int i = UnityEngine.Random.Range(0, MaxFruitsNo -1);
            generateFruits = fruits[i];
        }
        
        Instantiate(generateFruits, (Vector2)basePos.position,Quaternion.identity);
        firstFruits = false;
    }

    public void MergeFruits(FruitsController colfruits, int id)
    {
        if(id < 4)
        {
            id++;
            Debug.Log(fruits[id].name + "出現！");
        }
        else
        {
            Debug.Log("スイカはまだ");
        }
    }
}
