using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMPro.TextMeshProUGUI cardTitle;
    public TMPro.TextMeshProUGUI cardDescription;
    public Image cardSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        cardTitle.text = card.title;
        cardDescription.text = card.description;
        cardSprite.sprite = card.Item;
    }
}
