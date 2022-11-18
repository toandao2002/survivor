using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage_haunrs :  ShootBullet
{
    public static manage_haunrs Instance; 
     
    zombies zombie;
    public float speed;
    int dame = 20;
    /*  public bool is_sample = false;*/
    public long timeInitBullet = 2;
    float preTime = 0;
    float angle, radius = 2, angle_speed=0;
    Vector3 center_circle;
    public huanraojupan huar;
    List<huanraojupan> huanrs = new List<huanraojupan>();
    public int amount = 4;
    public void InitShoot()
    {
        center_circle = character.Instance.get_position();
        angle = (float)360 / amount;
        int cnt = huanrs.Count;
        if (huanrs.Count < amount)
            for (int i =cnt ; i < amount; i++)
            {
               

                huanrs.Add(Instantiate(huar, center_circle, Quaternion.identity));
                
            }
        int tmp = 0;
        foreach (var huar in huanrs)
        {
            center_circle = character.Instance.get_position();
            huar.transform.position = center_circle + new Vector3(Mathf.Cos((angle * tmp) * 3.14f / 180) * radius, Mathf.Sin(angle * tmp  * 3.14f / 180) * radius, 0);
            
            tmp++;
        }
        

    }
    public override void shoot()
    {

        angle = (float)360f / amount;

        InitShoot();
        amount++;

    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
        amount = 2;
            
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaySound());


    }
    IEnumerator PlaySound()
    {
        while (true)
        {
            ManageAudio.Instance.playSound((int)BulletName.huanr);
            yield return new WaitForSeconds(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*if (is_sample)
        {
            dame = 0;
            gameObject.SetActive(false);
            return;

        }*/
        for (int i = 0 ; i < huanrs.Count; i ++)
        {
             center_circle = character.Instance.get_position();
             huanrs[i]. transform.position = center_circle + new Vector3(Mathf.Cos(angle*  (i) * 3.14f / 180 + angle_speed) * radius, Mathf.Sin(angle * (i) * 3.14f / 180 + angle_speed) * radius, 0);   
        }
        angle_speed += speed;
        if (angle_speed >= 360) angle_speed = 360;
        
        
    }
    public override int GetDame()
    {
        return dame;
    }

    public override void SetDame(int value)
    {
        dame = value;
    }
}
