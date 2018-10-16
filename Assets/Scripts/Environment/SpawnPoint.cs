using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : Singleton<SpawnPoint>{
    void Start() 
    {
        gameObject.SetActive(false);
    }
}
