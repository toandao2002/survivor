using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletName
{
    kunai,
    huanr,
    brick,
    rocket

}
public abstract class ShootBullet : MonoBehaviour
{
    public bool is_sample =false ;
    public abstract int GetDame();
    public abstract void SetDame(int value);

    // Start is called before the first frame update
    public abstract void shoot( );
     
    
}
