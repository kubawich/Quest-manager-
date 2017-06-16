using UnityEngine;
using UnityEditor;
using System;

public class _Objective_Wizard : EditorWindow{

    static bool                 isFinished;
    static string               objName, objDesc = string.Empty;
    static UnityEngine.Object   dest;
    static int                  amount;

    public bool          iF;
    public string        oN, oD;
    public UnityEngine.Object d;
    public int           a;

    public _Quest_Manager_Editor man;

    private void OnEnable()
    {
        man = new _Quest_Manager_Editor();

    }
    public static  void Init()
    {
        _Objective_Wizard window = (_Objective_Wizard)EditorWindow.GetWindow(typeof(_Objective_Wizard), true, "Objective wizard");
        window.Show();
    }
    private void OnGUI()
    {
        isFinished  =   GUILayout.Toggle(isFinished,"Is objective done?");
        objName     =   EditorGUILayout.DelayedTextField("Name the objective", objName);
        objDesc     =   EditorGUILayout.DelayedTextField("Objective description", objDesc);
        dest        =   EditorGUILayout.ObjectField(dest, typeof(UnityEngine.Object), true);
        amount      =   EditorGUILayout.DelayedIntField(amount);
        if (GUILayout.Button("Add this objective"))
        {
            //AddObjective();
            if (man)
            {
                man.CreateObjective(isFinished, objName, objDesc, dest, amount);
                Debug.Log("Returned values " + isFinished + " " + objName + " " + objDesc + " " + dest.ToString() + " " + amount);
                this.Close();
            }
            else return;
        }

    }

    /*private void AddObjective()
    {
         if(man)
        {
            man.CreateObjective(isFinished, objName, objDesc, dest, amount);
        }
    }*/
}
