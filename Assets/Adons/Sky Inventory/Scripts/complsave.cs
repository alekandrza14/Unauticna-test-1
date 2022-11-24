﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class complsave : MonoBehaviour
{

    public rsave saveString1 = new rsave();
    public string name2;



    public string saveString221;


    public GameObject[] t3;




    public string[] nunames;


    public string[] info3;


    public void ResetItem()
    {

        for (int i = 0; i < GameObject.FindObjectsOfType<itemspawn>().Length; i++)
        {
            if (VarSave.GetBool("item" + SceneManager.GetActiveScene().name + i) == true)
            {


                
                VarSave.SetBool("item" + SceneManager.GetActiveScene().name + i, false);

            }
            
        }
        for (int i = 0; i < info3.Length; i++)
        {

            if (GameObject.FindGameObjectsWithTag(info3[i]).Length != 0)
            {



                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag(info3[i]).Length; i3++)
                {

                    GameObject.FindGameObjectsWithTag(info3[i])[i3].gameObject.AddComponent<deleter1>();


                }



            }



        }
        File.Delete(name2.ToString() + @"/scene_" + SceneManager.GetActiveScene().name);
        
    }
    public void getallitemsroom()
    {
        GameObject[] g = Resources.LoadAll<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex);
        nunames = new string[g.Length];
        for (int i = 0; i < nunames.Length; i++)
        {
            nunames[i] = g[i].name;

        }
        for (int i2 = 0; i2 < nunames.Length; i2++)
        {
            for (int i = 0; i < t3.Length; i++)
            {
                if (nunames[i2] != t3[i].name)
                {

                }
                if (nunames[i2] == t3[i].name)
                {
                    t3[i] = g[i2];
                    i2 = nunames.Length;
                        i = t3.Length;
                }

            }
        }
        }

        public void getallitems()
    {
        
        GameObject[] g = Resources.LoadAll<GameObject>("items");
        t3 = new GameObject[g.Length];
        info3 = new string[g.Length];
        for (int i = 0; i < g.Length; i++)
        {
            t3[i] = g[i];
            info3[i] = g[i].tag;

        }
        getallitemsroom();
    }





    public void Start()
    {
        getallitems();
        load();
        for (int i = 0; i < GameObject.FindObjectsOfType<itemspawn>().Length; i++)
        {
            if (VarSave.GetBool("item" + SceneManager.GetActiveScene().name + i) != true)
            {


                GameObject.FindObjectsOfType<itemspawn>()[i].sp();
                VarSave.SetBool("item" + SceneManager.GetActiveScene().name + i, true);

            }
            if (GameObject.FindObjectsOfType<itemspawn>().Length - 1 == i)
            {
                save();
            }
        }

    }
    private void Update()
    {
        for (int i = 0; i < info3.Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag(info3[i]).Length != 0)
            {


                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag(info3[i]).Length; i3++)
                {

                    
                    if (GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>())
                    {
                        GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>();
                    }
                    else 
                    { 
                        GameObject.FindGameObjectsWithTag(info3[i])[i3].AddComponent<breauty>().integer = 10;

                    }


                   

                }
            }

        }
        if (Input.GetKeyDown(KeyCode.F1))
        {


            save();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            load();
        }

    }


    public void save()
    {

        saveString1.vector3A.Clear();
        saveString1.id.Clear();



        for (int i = 0; i < info3.Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag(info3[i]).Length != 0)
            {


                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag(info3[i]).Length; i3++)
                {

                    saveString1.id.Add(i);
                    if (GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>())
                    {
                        saveString1.x.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<breauty>().integer);
                    }
                    else
                    {
                        saveString1.x.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].AddComponent<breauty>().integer = 10);

                    }
                    if (GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<Sphere>())
                    {
                        saveString1.PvectorA.Add(JsonUtility.ToJson(GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<Sphere>().p2));
                        saveString1.y.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].GetComponent<Sphere>().v1);
                    }
                    


                    saveString1.vector3A.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].transform.position);
                    saveString1.qA.Add(GameObject.FindGameObjectsWithTag(info3[i])[i3].transform.rotation);

                }
            }

        }

        









        Directory.CreateDirectory(name2.ToString());
        File.WriteAllText(name2.ToString() + @"/scene_" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));

        saveString1.vector3A.Clear();
        saveString1.PvectorA.Clear();
        saveString1.qA.Clear();
        saveString1.x.Clear();
        saveString1.y.Clear();
        saveString1.id.Clear();


    }
    public void load()
    {



        saveString1.vector3A.Clear();
        saveString1.id.Clear();

        saveString221 = Path.Combine("", name2 + @"/scene_" + SceneManager.GetActiveScene().name);



        if (File.Exists(saveString221))
        {
            saveString1 = JsonUtility.FromJson<rsave>(File.ReadAllText(saveString221));

            Debug.Log("IU");
        }
        else
        {
            Debug.Log("IU2");

            File.WriteAllText(name2 + @"/scene_" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(saveString1));
            saveString1 = JsonUtility.FromJson<rsave>(File.ReadAllText(saveString221));

        }












        for (int i = 0; i < info3.Length; i++)
        {

            if (GameObject.FindGameObjectsWithTag(info3[i]).Length != 0)
            {



                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag(info3[i]).Length; i3++)
                {

                    GameObject.FindGameObjectsWithTag(info3[i])[i3].gameObject.AddComponent<deleter1>();


                }



            }



        }



        if (saveString1.PvectorA.Count == 0)
        {


            for (int i3 = 0; i3 < saveString1.id.Count; i3++)
            {




                Debug.Log("1");
                GameObject g = Instantiate(t3[saveString1.id[i3]].gameObject, new Vector3(saveString1.vector3A[i3].x, saveString1.vector3A[i3].y, saveString1.vector3A[i3].z), saveString1.qA[i3]);
                if (!g.GetComponent<breauty>())
                {


                    g.AddComponent<breauty>().integer = saveString1.x[i3];
                }
                else
                {
                    g.GetComponent<breauty>().integer = saveString1.x[i3];
                }


            }
        }else
        {
            for (int i3 = 0; i3 < saveString1.id.Count; i3++)
            {




                Debug.Log("1");
                GameObject g = Instantiate(t3[saveString1.id[i3]].gameObject, new Vector3(0, 0, 0), saveString1.qA[i3]);
                if (!g.GetComponent<breauty>())
                {


                    g.AddComponent<breauty>().integer = saveString1.x[i3];
                }
                else
                {
                    g.GetComponent<breauty>().integer = saveString1.x[i3];
                }
                if (!g.GetComponent<Sphere>())
                {


                    g.AddComponent<Sphere>().p2 = JsonUtility.FromJson<PolarTransform>(saveString1.PvectorA[i3]);

                    g.GetComponent<Sphere>().v1 = saveString1.y[i3];
                }
                else
                {
                    g.GetComponent<Sphere>().p2 = JsonUtility.FromJson<PolarTransform>(saveString1.PvectorA[i3]);

                    g.GetComponent<Sphere>().v1 = saveString1.y[i3];
                }


            }
        }













        }


    }
    [SerializeField]

public class rsave
{
    
    public List<Vector3> vector3A = new List<Vector3>();
    public List<string> PvectorA = new List<string>();
    public List<Quaternion> qA = new List<Quaternion>();
    public List<int> x = new List<int>();
    public List<float> y = new List<float>();
    public List<int> id = new List<int>();
    
    




}


