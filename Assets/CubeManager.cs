//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public float speed = 2f;
    public GameObject _cubePrefab;
    private Rigidbody rigidBody;
    public List<int> walkList = new List<int>();
    private List<GameObject> cubes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //walkList = RandomList(20000000);
        walkList = RandomList(41);
        StartCoroutine(CubeGenerator());

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var cube in cubes)
        {
            Transform trans = cube.GetComponent<Transform>();
            ChangeTransform(trans, walkList);
        }
    }

    IEnumerator CubeGenerator()
    {
        for (int i = 160; i > 0; i--)
        {
            var randi = Random.Range(-40, 40);
            var randj = Random.Range(-40, 40);
            var randk = Random.Range(-40, 40);

            Vector3 pos = new Vector3(randi, randj, randk);
            GameObject CubeE = Instantiate(_cubePrefab, pos, Quaternion.identity) as GameObject;

            CubeE.AddComponent<Rigidbody>().isKinematic = true;
            rigidBody = CubeE.GetComponent<Rigidbody>();
            rigidBody.useGravity = false;
            cubes.Add(CubeE);

            yield return new WaitForSeconds(0.01f);
            // ChangeTransform(CubeE.transform, walkList);
        }
    }

    public void ChangeTransform(Transform trans, List<int> list)
    {
        System.Random rand = new System.Random();
        trans.position +=
                                /*new Vector3(
                                    list[rand.Next(list.Count)],
                                    list[rand.Next(list.Count)],
                                    list[rand.Next(list.Count)]
                                    ) */
                                -Vector3.up * Time.deltaTime * speed;

        // let cubes loop through
        if (trans.position.y < -40f)
            trans.position = new Vector3(trans.position.x, 40f, trans.position.z);


        //for (int i = 0; i < list.Count; i++)
        //    for (int j = list.Count; j > 0; j--)
        //        for (int k = -list.Count; k < 0; k++)
        //        {
        //            trans.position += new Vector3(list[i], list[j], list[k]) * Time.deltaTime;
        //        }
    }



    /// <summary>
    /// Generate a random value list 
    /// </summary>
    /// <param name="length"></param>
    public List<int> RandomList(int length)
    {
        System.Random rand = new System.Random();

        for (int i = 0; i < length; i++)
        {
            var num = rand.Next(-20, 20);
            walkList.Add(num);
        }

        return walkList;

        //var choiceList = new List<int> { -1, 1 };
        //System.Random rand = new System.Random();

        //for (int i = 0; i < length; i++)
        //{
        //    int index = rand.Next(choiceList.Count);
        //    walkList.Add(choiceList[index]);
        //}
        //return walkList;
    }

}

