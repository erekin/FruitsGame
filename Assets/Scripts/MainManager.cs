using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Vector2 basePos;
    [SerializeField] private Transform firstPos;
    [SerializeField] private FruitsController[] fruits;
  
    private bool firstFruits;
    public int MaxFruitsNo { get; private set; }

    void Start()
    {
        //firstFruits = true;
        //generateFruits = fruits[0];

        MaxFruitsNo = fruits.Length;
        FruitsGenerate();
    }

    void Update()
    {

    }

    public void FruitsGenerate()
    {
        int i = Random.Range(0, MaxFruitsNo - 2);
        Debug.Log(i);
        FruitsController fruitsIn = Instantiate(fruits[i], firstPos);
        fruitsIn.id = i;
        fruitsIn.gameObject.SetActive(true);
        //firstFruits = false;
    }

    //private GameObject changeObj;
    private bool isMerge = false;
    //private void ChangeFruits(int id,GameObject obj)
    //{
    //    id++;
    //    changeObj = fruits[id];
    //    if (!isMerge)
    //    {
    //        Instantiate(changeObj, obj.transform.position, Quaternion.identity);
    //        isMerge = true;
    //    }

    //}

    public void MergeNext(Vector3 target,int id)
    {
        FruitsController fruitsIns = Instantiate(fruits[id + 1], target, Quaternion.identity, firstPos);
        fruitsIns.id = id + 1;
        fruitsIns.GetComponent<Rigidbody2D>().gravityScale = 2.0f;

    }
}
