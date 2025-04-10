using System.Collections;
using System.Collections.Generic;
using Game.S.Scripts.MVC.Model;
using UnityEditor;
using UnityEngine;

public class ControladorMisc : MonoBehaviour
{
    public void DeletarPastaSave()
    {
        System.IO.Directory.Delete(Diretorios.SavePath);
    }
    
    public void DeletarPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
