using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] MainManager mainManager;

    private Vector3 offset;
    private float yPos_fixed;   //y座標を固定
    private Rigidbody2D rb;

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

    private void OnMouseUp()
    {
        rb.gravityScale = 2;
        Invoke("NextGenerate",1.0f);
    }

    private void NextGenerate()
    {
        mainManager.FruitsGenerate();
    }

    private Vector3 GetMousePos()
    {
        return _cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
