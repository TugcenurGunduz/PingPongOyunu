﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Load(int index)
    {
        SceneManager.LoadScene(index);//index noya göre sahneyi yükler
    }
}
