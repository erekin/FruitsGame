using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankController : FruitsController
{
    public int blankID = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("blank"))
        {
            mainManager.TouchFruits(blankID, this.gameObject);
        }
    }

}
