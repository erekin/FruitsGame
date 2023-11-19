using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Transform basePos;
    [SerializeField] private GameObject[] fruits;
  
    private bool firstFruits;
    private GameObject generateFruits;
    private int MaxFruitsNo;
    public bool gravityFlag;

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
        gravityFlag= false;
    }

    public void MergeFruits(FruitsController colfruits, int id)
    {
        if(id < 4)
        {
            id++;
            Instantiate(fruits[id], colfruits.transform.position, Quaternion.identity);
            gravityFlag= true;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("Main"); 
    }
}
