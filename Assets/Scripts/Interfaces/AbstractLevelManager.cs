using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLevelManager : MonoBehaviour
{
    public abstract void Victory();

    public abstract void GameOver();
}
