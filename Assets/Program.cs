using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class Program : MonoBehaviour
{
    [STAThread]
    public void Main()
    {
        try
        {
            Process.Start(@"C:\exist"); // �w�肵���t�H���_���J��
            Process.Start(@"C:\does_not_exist"); // System.ComponentModel.Win32Exception
        }
        catch (Exception e)
        {
            Console.WriteLine(e.GetType());
        }
    }
}
