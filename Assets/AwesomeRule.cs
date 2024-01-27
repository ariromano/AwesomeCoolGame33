using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AwesomeRule", menuName = "AwesomeGame/Rule", order = 1)]
public class AwesomeRule: ScriptableObject
{
    public Texture2D image;
    public string name;
    public RuleType type;
}

public enum RuleType{
    instant,
    environmental,
    spawn
}

