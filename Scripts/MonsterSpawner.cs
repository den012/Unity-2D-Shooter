using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] monsterReference;

    public GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    public bool run = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while(run)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 1f));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0,2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if(randomSide == 0) //left side
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monsters>().speed = Random.Range(2,5);
            }
            else  //rights side
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(2,5);
                spawnedMonster.transform.localScale = new Vector3(-1.6f, 1.6f, 1.6f);
            }
        }
    }
}
