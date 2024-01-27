using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AwesomeRule: ScriptableObject
{
    public Texture2D image;
    public string ruleName;
    //public RuleType type;
	public abstract void Trigger();
}
/*
public enum RuleType{
    instant,
    environmental,
    spawn,
	character
}

*/