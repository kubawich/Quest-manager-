using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(_Quest_Manager))]
[Serializable]
public class _Quest_Manager_Editor : Editor {

    public _Quest_Manager      db;
    public _Objective_Wizard wizard;

    void OnEnable () {
        db = target as _Quest_Manager;
        db.objectives.Clear();
        db.quests.Clear(); 
    }

    public override void OnInspectorGUI () {
        serializedObject.Update();
        GUILayout.BeginVertical("box");
        if (GUILayout.Button("New quest")) AddQuest();
        if (GUILayout.Button("Delete quests")) Remove();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Quests: " + db.quests.Count);
        GUILayout.Label("Objectives " + db.objectives.Count);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        if (db.quests != null) 
        DrawQuests();
    }

    void AddQuest()
    {
        db.quests.Add(new _Quest());
    }

    void Remove()
    {
        db.quests.Clear();
        db.quests.Capacity = 0;
    }


   public void CreateObjective(bool iF, string oN, string oD, UnityEngine.Object De, int Am)
    {
        db.objectives.Add(new _Objective_Element(iF, oN, oD, De, Am));
        Debug.Log("Suceed");
    }

    void DrawQuests()
    {
        for (int i = 0; i <= db.quests.Count; i++)
        {
            if (db.quests.Count != 0)
            {
                GUILayout.BeginVertical("box");
                GUILayout.BeginHorizontal();

                EditorGUILayout.LabelField(i.ToString(), GUILayout.MaxWidth(18));
                if (db.quests[i].name == String.Empty || db.quests[i].name == null)
                    db.quests[i].name = EditorGUILayout.DelayedTextField("Quest name ", db.quests[i].name);
                else EditorGUILayout.LabelField(db.quests[i].name);

                GUILayout.EndHorizontal();
                GUILayout.Space(8);

                if (GUILayout.Button("New Objective"))
                {
                    _Objective_Wizard.Init();
                }

                if(db.objectives.Count != 0)
                {
                    int j = 0;
                    foreach (var el in db.objectives)
                    {             
                        GUILayout.Label(db.objectives[j].Name.ToString());
                        GUILayout.Label(db.objectives[j].description.ToString());
                        db.objectives[j].IsFinished = GUILayout.Toggle(db.objectives[j].IsFinished, "Finished?");
                        db.objectives[j].Destination = EditorGUILayout.ObjectField(db.objectives[j].Destination, typeof(UnityEngine.Object), true);
                        db.objectives[j].Amount = EditorGUILayout.DelayedIntField(db.objectives[j].Amount);
                        j++;
                    }
                }

                GUILayout.Space(4);

                GUILayout.EndVertical();
            }

        }
    }
}
