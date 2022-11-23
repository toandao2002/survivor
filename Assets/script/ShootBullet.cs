using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletName
{
    kunai,
    huanr,
    brick,
    rocket,
    zuanto,
    example,

}
public abstract class ShootBullet : MonoBehaviour
{   
    public int level;
    public ParticleSystem collisionEnemyFx;
    float widthcam, heightcam;
    public Camera cam ;
    Vector3 cam_pos ;
    
    public abstract int GetDame();
    public abstract void SetDame(int value);
    public abstract long  get_init_bullet();
    // Start is called before the first frame update
    public abstract void shoot( );


    public virtual void CollisionWithZombie(Transform zombie)
    {
        collisionEnemyFx.Play();
    }
    public GameObject FindZombieNearest()
    {
        GameObject des = null;
        int min_dis = int.MaxValue;
        foreach (GameObject zombie in manage_zombie.Instace.zombies)
        {
            if (zombie == null) continue;
            int tmp = (int)Vector3.Distance(character.Instance.gameObject. transform.position, zombie.transform.position);
            if (tmp < min_dis)
            {
                min_dis = tmp;
                des = zombie;
               
            }
        }
        return des;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            //CollisionWithZombie(collision.transform);
        }
    }
     
    public bool OutOfSreen()
    {
        if (cam == null)
        {
            cam = control_camera.Instance.GetCamera(); 
        }
        cam_pos = control_camera.Instance.get_position();
        heightcam = 2f * cam.orthographicSize;
        widthcam = heightcam * cam.aspect;
        if (transform.position.x  > cam_pos.x  + widthcam || transform.position.x < cam_pos.x - widthcam
            || transform.position.y > cam_pos.y + heightcam || transform.position.y < cam_pos.y - heightcam)
        {
            return true;
        }
            
        return false;
    }
    
}
