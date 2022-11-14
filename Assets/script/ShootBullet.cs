using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ShootBullet 
{
    int GetDame();
    void SetDame(int value);

    // Start is called before the first frame update
    void shoot(zombies zombies, float speed, float dame );
     
    
}
