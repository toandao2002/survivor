using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectpoolBullet : MonoBehaviour
{
    public static ObjectpoolBullet Instance;
    // Start is called before the first frame update
    Dictionary<int, List<GameObject>> PooledObject = new Dictionary<int, List<GameObject>>();
    [SerializeField] private List <GameObject> BulletPrefabs;
     
    int amountTopool = 20;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
         
    }
    public GameObject GetPooledObject (int id )
    {
        if (!PooledObject.ContainsKey(id))
        {
            PooledObject[id] = new List<GameObject>();
        }
        for (int i = 0; i < PooledObject[id].Count; i++)
        {
            if (!PooledObject[id][i].activeInHierarchy)
            {
                PooledObject[id][i].SetActive(true);
                return PooledObject[id][i];
            }
        }

        GameObject gobj =   Instantiate(BulletPrefabs[id]);
        PooledObject[id].Add(gobj);
        return gobj; 
    }
     
}
