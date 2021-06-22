using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;

public class LeaderboardManager : MonoBehaviour
{
    DatabaseReference reference;
    public Text name1,score1,name2,score2,name3,score3;
    // Start is called before the first frame update
    void Awake()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GetReference("users").ValueChanged += Script_ValueChanged ;
    }
    public void showRank()
    {
        
    }
    void Script_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        name1.text = e.Snapshot.Child("1").Child("Name").GetValue(true).ToString();
        score1.text = e.Snapshot.Child("1").Child("Score").GetValue(true).ToString();
        name2.text = e.Snapshot.Child("2").Child("Name").GetValue(true).ToString();
        score2.text = e.Snapshot.Child("2").Child("Score").GetValue(true).ToString();
        name3.text = e.Snapshot.Child("3").Child("Name").GetValue(true).ToString();
        score3.text = e.Snapshot.Child("3").Child("Score").GetValue(true).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
