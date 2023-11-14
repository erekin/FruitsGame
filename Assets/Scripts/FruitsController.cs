using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    [SerializeField] Camera _cam;
    public MainManager mainManager;

    private Vector3 offset;
    private float yPos_fixed;   //y座標を固定
    private Rigidbody2D rb;
    public int id;

    private void Start()
    {
        //y座標を固定
        yPos_fixed = gameObject.transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnMouseDown()
    {    
        offset = gameObject.transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + offset ;
        //y座標のドラッグの値を固定
        Vector3 pos = transform.position;
        pos.y = yPos_fixed;
        transform.position = pos;
    }

    private Vector3 GetMousePos()
    {
        return _cam.ScreenToWorldPoint(Input.mousePosition);
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

    private bool isMerge = false;
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colObj = collision.gameObject;

        if (colObj.gameObject.CompareTag("fruits"))
        {
            FruitsController colFruits = collision.gameObject.GetComponent<FruitsController>();
            if (id == colFruits.id &&
                     !isMerge &&
                     !colFruits.isMerge &&
                     id < mainManager.MaxFruitsNo - 1){
                isMerge = true;
                colFruits.isMerge = true;
                mainManager.MergeNext(transform.position, id);
                Destroy(gameObject);
                Destroy(colFruits.gameObject);
            }
        }

        //if(collision.gameObject.CompareTag("blank"))
        //{
        //    mainManager.TouchFruits(id,this.gameObject);
        //}
    }
}
