using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsController : MonoBehaviour
{
    [SerializeField] Camera _cam;
    public MainManager mainManager;

    private Vector3 offset;
    private float yPos_fixed;   //y���W���Œ�
    private Rigidbody2D rb;
    private int id;

    private void Start()
    {
        //y���W���Œ�
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
        //y���W�̃h���b�O�̒l���Œ�
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

    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("blank"))
        {
            mainManager.TouchFruits(id,this.gameObject);
        }
    }
}
