using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class StatsBarMenu : MonoBehaviour
{
    public GameObject slider;
    public int maxSize;
    public bool fixedSize;
    public bool sqrt;
    [SerializeField]
    private PotionAttributeCollection allAttributes;
    [SerializeField]
    private float sliderSpeed;
    private PotionAttributeCollection attributes;

    private struct SliderStruct 
    {
        public SliderStruct(GameObject instantiator) 
        {
            slider = instantiator;
            image = slider.GetComponentInChildren<Image>();
            text = slider.GetComponentInChildren<Text>();
        }
        public GameObject slider;
        public Image image;
        public Text text;

    }
    private Dictionary<PotionAttributeScriptableObject, SliderStruct> sliders = new Dictionary<PotionAttributeScriptableObject, SliderStruct>();
    public void Display(PotionAttributeCollection attributes) 
    {
        this.attributes = attributes;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxSize = Mathf.Min(maxSize, allAttributes.AttributeDict.Count);
        foreach (var attribute in allAttributes.AttributeDict) 
        {
            sliders.Add(attribute.Key, new SliderStruct(GameObject.Instantiate(slider, gameObject.transform)));
            sliders[attribute.Key].text.text = attribute.Key.displayName;
            sliders[attribute.Key].image.rectTransform.sizeDelta += new Vector2(-100,0);
            sliders[attribute.Key].image.color = attribute.Key.attributeColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fixedSize)
        {
            foreach (var item in sliders) 
            {
                var attribute = item.Key;
                var slider = item.Value;

                var curr = slider.image.rectTransform.sizeDelta.x - 3;
                float value = 0f;
                if (attributes.AttributeDict.ContainsKey(attribute)) 
                {
                    value = attributes.AttributeDict[attribute];
                }
                float change = (value - curr) * sliderSpeed;

                slider.image.rectTransform.sizeDelta += new Vector2(change * Time.deltaTime, 0);
            }
        }
        else
        {
            if (sqrt)
            foreach (var item in sliders) 
            {
                var attribute = item.Key;
                var slider = item.Value;

                var curr = slider.image.rectTransform.sizeDelta.x - 3;
                float value = 0f;
                if (attributes.AttributeDict.ContainsKey(attribute)) 
                {
                    value = attributes.AttributeDict[attribute];
                }

                value = Mathf.Sqrt(value / 100) * 100;

                float change = (value - curr) * sliderSpeed;

                slider.image.rectTransform.sizeDelta += new Vector2(change * Time.deltaTime, 0);
            }


            else 
            {
                float maxVal = 0f;
                foreach (var item in sliders) 
                {
                    var attribute = item.Key;
                    var slider = item.Value;

                    var curr = slider.image.rectTransform.sizeDelta.x - 3;
                    float value = 0f;
                    if (attributes.AttributeDict.ContainsKey(attribute)) 
                    {
                        value = attributes.AttributeDict[attribute];
                    }

                    maxVal = Mathf.Max(maxVal, value);
                }
                maxVal += 10;
                foreach (var item in sliders) 
                {
                    var attribute = item.Key;
                    var slider = item.Value;

                    var curr = slider.image.rectTransform.sizeDelta.x - 3;
                    float value = 0f;
                    if (attributes.AttributeDict.ContainsKey(attribute)) 
                    {
                        value = attributes.AttributeDict[attribute];
                    }

                    value = value / maxVal * 70 + value * 0.3f;

                    float change = (value - curr) * sliderSpeed;

                    slider.image.rectTransform.sizeDelta += new Vector2(change * Time.deltaTime, 0);
                }
            }
        }

    }
}
