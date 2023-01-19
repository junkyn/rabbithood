using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAura : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer rend;
    AudioSource audioSource;
    // Update is called once per frame
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (TeleportArrow.Arrived)
        {
            StartCoroutine(Aura());
            audioSource.Play();
        }
    }
    IEnumerator Aura()
    {
        float fadeCount = 0;
        while (fadeCount< 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            rend.color = new Color(255, 255, 255, fadeCount);
        }
        while (fadeCount > 0f)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            rend.color = new Color(255, 255, 255, fadeCount);
        }
    }
}
