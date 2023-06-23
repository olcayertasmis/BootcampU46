using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCharacterPosition : MonoBehaviour
{
    public float[] konum;
    private void Start()
    {
        Load();
        transform.position =new Vector3(konum[0], konum[1], konum[2]);
        transform.rotation = new Quaternion(konum[3], konum[4], konum[5], konum[6]);
    }
    private void Update()
    {
        konum[0] = transform.position.x;
        konum[1] = transform.position.y; 
        konum[2] = transform.position.z;
        konum[3] = transform.rotation.x;
        konum[4] = transform.rotation.y;
        konum[5] = transform.rotation.z;
        konum[6] = transform.rotation.w;
    }
    private void OnApplicationQuit() //oyun kapandýðýnda ne yapýcaðýmýzý söylüyoruz.
    {
        Save();
    }
    public void Save()
    {
        for(int i=0; i<konum.Length; i++)
        {
            PlayerPrefs.SetFloat("sd" + i, konum[i]);
        }
    }
    public void Load()
    {
        for(int i = 0; i< konum.Length; i++)
        {
            konum[i]=PlayerPrefs.GetFloat("sd"+ i, konum[i]);
        }
    }
}
