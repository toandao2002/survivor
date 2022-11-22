using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolZombie : MonoBehaviour
{
    public static ObjectPoolZombie Instance;
    Dictionary<int, List<GameObject>> PooledObject = new Dictionary<int, List<GameObject>>();
     
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetPooledObject(int id)
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

        GameObject gobj = Instantiate(manage_zombie.Instace. prefab_zombie[id]);
        PooledObject[id].Add(gobj);
        return gobj;
    }
}
