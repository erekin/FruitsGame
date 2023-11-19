using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    [SerializeField] Camera _cam;

    private MainManager mainManager;
    private float yPos_fixed;   //y座標を固定
    private Rigidbody2D rb;
    public bool isMerge;
    public int fruitsID;
    public string ownName;

    private void Start()
    {
        mainManager = GameObject.FindWithTag("MainManager").GetComponent<MainManager>();
        //y座標を固定
        yPos_fixed = gameObject.transform.position.y;
        rb = GetComponent<Rigidbody2D>();

        if (!mainManager.gravityFlag)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }

        ownName = gameObject.name;
        ownName = ownName.Substring(0,ownName.Length-"(clone)".Length);
        fruitsID = GetIndex();
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)_cam.ScreenToWorldPoint(Input.mousePosition);
        //y座標のドラッグの値を固定
        Vector3 pos = transform.position;
        pos.y = yPos_fixed;
        transform.position = pos;
    }

    private void OnMouseUp()
    {
        rb.gravityScale = 2;
        Invoke("NextGenerate",1.0f);
    }

    private void NextGenerate()
    {
        mainManager.FruitsGenerate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colObj = collision.gameObject;
        if (colObj.CompareTag("fruits"))
        {
            FruitsController colFruits = collision.gameObject.GetComponent<FruitsController>();
            if(gameObject.name == colFruits.name && !isMerge && !colFruits.isMerge)
            {
                mainManager.MergeFruits(colFruits,fruitsID);
                isMerge = true;
                colFruits.isMerge = true;
                StartCoroutine(DestroyObj(colFruits.gameObject));
            }
        }
    }

    private int GetIndex()
    {      
        int index = 0;
        switch(ownName)
        {
            case  "blank":
                index = 0;
                break;

            case "plum":
                index = 1;
                break;

            case "bell":
                index = 2;
                break;

            case "Suica":
                index = 3;
                break;

            case "Cherry":
                index = 4;
                break;

            default:
                index = 999;
                break;
        }
        return index;
    }

    IEnumerator DestroyObj(GameObject colObj)
    {
        yield return new WaitForSeconds(0.05f);

        Destroy(gameObject);
        Destroy(colObj.gameObject);
    }
}
