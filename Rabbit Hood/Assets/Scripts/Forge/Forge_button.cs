using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Forge_button : MonoBehaviour
{
    bool isclicked = false;
    Image img;
    GameObject backimg;

    

    private void Start()
    {
        backimg = this.transform.GetChild(1).gameObject;
        img = backimg.GetComponent<Image>();

        EventTrigger eventTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry_PointerUp = new EventTrigger.Entry();
        entry_PointerUp.eventID = EventTriggerType.PointerUp;
        entry_PointerUp.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerUp);

        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);

       
    }
    private void Update()
    {
        if (isclicked)
        {
            img.fillAmount += 0.005f;
        }
        if(!isclicked && img.fillAmount >= 0)
        {
            img.fillAmount -= 0.005f;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        isclicked = false;
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        isclicked = true;
    }
}
