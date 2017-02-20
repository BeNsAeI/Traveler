using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunProperty : MonoBehaviour {
    public string Name = "";
    public bool Riffle = false;
    private bool Handgun = true;
    public bool Automatic = false;
    public string Description = "Looks like and ordinary gun to me!";
    public int AmmoCount = 0;
    public int Accuracy = 0;
    public int RPCMode = 0;
}
