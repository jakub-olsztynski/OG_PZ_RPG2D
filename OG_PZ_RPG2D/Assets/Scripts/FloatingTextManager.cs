using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>(); //lista od razu inicjowana

    public void Show(string msg, Vector3 position, Vector3 motion, float duration) //by³o:(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.txt.text = msg;
        //floatingText.fontSize = fontSize; //TODO:fix
        //floatingText.color = color; 
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); //worldspace na screenspace, inaczej 1 oznacza 1 piksel a nie 1 "jednostke"
        floatingText.motion = motion;
        floatingText.duration = duration;
        floatingText.Show(); //odpala tekst

    }

    private void Update()
    {
        foreach(FloatingText txt in floatingTexts)
            txt.UpdateFloatingText(); //musialem tak zrobic bo inaczej sie nie updatuje, FloatingText nie dziedziczy juz po MonoBehavious wiec nie ma tam Update
    }

    private FloatingText GetFloatingText() //sprawdza czy jest jakis nieatywny floatingtext, jak nie ma to tworzy i dodaje do listy. zwraca znaleziony/stworzony floatingText
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);
        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<TextMeshProUGUI>();

            floatingTexts.Add(txt);
        }
        return txt;
    }

}
