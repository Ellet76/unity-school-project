using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePauseSprite : MonoBehaviour
{
    public Sprite pause;
    public Sprite play;
    private Image image;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (PauseTime.timeActive)
        {
            image.sprite = play;
        }
        if (!PauseTime.timeActive)
        {
            image.sprite = pause;
        }
    }
}
