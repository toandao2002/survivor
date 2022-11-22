using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Increase_EXP : MonoBehaviour
{
    private  bool isCollide = false ;
    Rigidbody2D rig;
   
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollide == true)
        {
            DG.Tweening.DOVirtual.DelayedCall(0.8f, () =>
            {
                Destroy(this.transform.parent.gameObject);
            });
 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isCollide== false )
        {
            isCollide = true;
            ani.Play("effectEXP");
            
        }
    }
}
