using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question")]
public class Question : ScriptableObject
{
    public string text,answer,wrongAnswer1,wrongAnswer2,wrongAnswer3;
    public int pointsAwarded = 100;
}
