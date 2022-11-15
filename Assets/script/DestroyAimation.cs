using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).length <
            ani.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            Destroy(this.transform.parent.gameObject);

        }
    }
}
