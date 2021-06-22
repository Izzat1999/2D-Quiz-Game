using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    [SerializeField] private Image image;
    private int pressed;
    private int i = -1;
    private int score = 0;
    DatabaseReference reference;
    
    void Start()
    {
        // FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://emergencynoquiz-default-rtdb.asia-southeast1.firebasedatabase.app/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        manager();
    }

    void manager()
    {
        pressed = 0;
        i++;

        if(i < questions.Length)
            image.sprite = questions[i].image;
        else
        {
            Debug.Log(score);

            reference.Child("users").Child("1").Child("Name").SetValueAsync(PhotonNetwork.playerName);
            reference.Child("users").Child("1").Child("Score").SetValueAsync(score);
            StartCoroutine(NextQuestion());
            PhotonNetwork.LoadLevel("Leaderboard");
        }
            
        Invoke("manager", 5f); 
    }
    public void Button1()
    {
        pressed = 1;

        if(questions[i].answer == pressed)
        {
            Debug.Log("correct");
            score+=10;
        }
        manager();
    }
    public void Button2()
    {
        pressed = 2;

        if(questions[i].answer == pressed)
        {
            Debug.Log("correct");
            score+=10;
        }
        manager();
    }
    public void Button3()
    {
        pressed = 3;

        if(questions[i].answer == pressed)
        {
            Debug.Log("correct");
            score+=10;
        }
        manager();
    }
    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(10f);
    }
}
