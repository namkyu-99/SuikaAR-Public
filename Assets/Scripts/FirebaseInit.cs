using System;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using JetBrains.Annotations;
using TMPro;
using Unity.Properties;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    DatabaseReference reference;
    // public TMP_Text loadData;
    public TMP_Text firstName;
    public TMP_Text firstScore;
    public TMP_Text secondName;
    public TMP_Text secondScore;
    public TMP_Text thirdName;
    public TMP_Text thirdScore;
    public TMP_Text restName;
    public TMP_Text restScore;
    List<Rank> dataList = new();
    
    void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Firebase has been initialized.");
                
                // rest.text += "Firebase has been initialized.\n";

                // AppOptions options = new AppOptions { DatabaseUrl = new Uri("https://suikaar-2c888-default-rtdb.firebaseio.com/")};
                // FirebaseApp app = FirebaseApp.Create(options);

                reference = FirebaseDatabase.DefaultInstance.GetReference("rank");
                // rest.text += reference + "\n";
            }
            else
            {
                Debug.LogError("Firebase initialization failed: " + dependencyStatus);

                // rest.text = "Firebase initialization failed: " + dependencyStatus + "\n";
            }
        });
    }

    void Clear()
    {
        firstName.text = "";
        secondName.text = "";
        thirdName.text = "";
        restName.text = "";
        firstScore.text = "";
        secondScore.text = "";
        thirdScore.text = "";
        restScore.text = "";
    }

    public void LoadData()
    {
        dataList.Clear();
        Clear();

        reference.GetValueAsync().ContinueWithOnMainThread(task => 
        {
            if (task.IsFaulted)
            {
                // loadData.text = "Load Failed: " + task.Exception;
                restName.text += "Load Failed: " + task.Exception + "\n";
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    // loadData.text = "Load Successed\n";
                    // rest.text += "Load Successed\n";

                    foreach(DataSnapshot child in snapshot.Children)
                    {
                        string json = child.GetRawJsonValue();
                        Rank data = new(json);
                        dataList.Add(data);
                    }
                    SortByScore();
                }
                else
                {
                    // loadData.text = "Data is not exist";
                    restName.text += "Data is not exist\n";
                    return;
                }
            }
        });
    }
    
    public void SortByScore()
    {
        dataList.Sort((x,y) => y.score.CompareTo(x.score));

        // rest.text += "SortByScore\n";

        int num = 1;
        foreach (var data in dataList)
        {
            // loadData.text += data.ToString();

            string[] splitData = data.ToString().Split('|');
            string name = splitData[0];
            string score = splitData[1];

            if (num==1)
            {
                firstName.text = name;
                firstScore.text = score;
            }
            if (num==2)
            {
                secondName.text = name;
                secondScore.text = score;
            }
            if (num==3)
            {
                thirdName.text = name;
                thirdScore.text = score;
            }
            if (num>3)
            {
                restName.text += name;
                restScore.text += score;
            }
            num++;
        }
    }

    public void AddScore(string name, long score)
    {
        Rank user = new(name, score);

        // 쿼리를 사용해서 name이 일치하는 노드 검색
        Query query = reference.OrderByChild("name").EqualTo(name);
        query.GetValueAsync().ContinueWithOnMainThread(task => {
            // 쿼리 실행 도중 오류 발생시 AddScore종료. 
            if (task.IsFaulted)
            {
                return;
            }
            // 오류가 없을 시
            else if (task.IsCompleted)
            {
                DataSnapshot node = task.Result;

                // 이름이 같은 노드가 존재할 시
                if (node.Exists)
                {
                    foreach (DataSnapshot childNode in node.Children)
                    {
                        long originScore = long.Parse(childNode.Child("score").Value.ToString());
                        if (score>originScore) childNode.Reference.Child("score").SetValueAsync(score);
                    }
                }
                // 이름이 같은 노드가 없을 시
                else
                {
                    string json = JsonUtility.ToJson(user);
                    string key = reference.Push().Key;
                    reference.Child(key).SetRawJsonValueAsync(json);
                }
                LoadData();
            }
        });
    }
    public void ResetData()
    {
        dataList.Clear();
        Clear();

        reference.SetValueAsync(null).ContinueWith(task => 
        {
            if (task.IsFaulted) restName.text += "Reset Faulted: " + task.Exception;
        });
    }

    public class Rank
    {
        public string name;
        public long score;

        public Rank(string name, long score)
        {
            this.name = name;
            this.score = score;
        }
        public Rank(string json)
        {
            JsonUtility.FromJsonOverwrite(json,this);
        }
        public override string ToString()
        {
            return $"{name}\n|{score}\n";
        }
    }
}
