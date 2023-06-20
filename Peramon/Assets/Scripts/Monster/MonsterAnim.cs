using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnim : MonoBehaviour
{
    BaseMonster _baseMonster;
    [SerializeField] float _randomRange = 1f;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        _baseMonster = transform.GetChild(0).gameObject.GetComponent<BaseMonster>();
        StartCoroutine(NewMoveVector());
    }

    // Update is called once per frame
    void Update()
    {
        if (_baseMonster.isSpecial)
        {
            SpecialAnim();
        }
    }

    void SpecialAnim()
    {
        this.gameObject.transform.position += newPos * Time.deltaTime;
    }

    IEnumerator NewMoveVector()
    {
        while (true)
        {
            newPos = new Vector3(Random.Range(-_randomRange, _randomRange), 0f, Random.Range(-_randomRange, _randomRange));
            yield return new WaitForSeconds(3f);
        }
    }
}
