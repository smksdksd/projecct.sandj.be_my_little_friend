using System;

[Serializable]
public class Adopter
{
    public string name;
    public string description;
    public float preferredAffection;

    public Adopter(string name, string desc, float affection)
    {
        this.name = name;
        this.description = desc;
        this.preferredAffection = affection;
    }
}