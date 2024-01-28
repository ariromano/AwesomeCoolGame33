using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	public float barFill = 0.5f;
	public float barMaxFill = 4.0f;
	public float barHeight = 0.2f;

	public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.rectTransform.sizeDelta = new Vector2(barFill * barMaxFill, barHeight);
    }
}
