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
    [SerializeField]
    private PotionAttributeCollection allAttributes;
    
    private float sliderSpeed = 0.5f;
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
            sliders[attribute.Key].slider.transform.position += sliders.Count * new Vector3(0, -12, 0);
            sliders[attribute.Key].text.text = attribute.Key.displayName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in sliders) 
        {
            var attribute = item.Key;
            var slider = item.Value;

            var scale = slider.image.rectTransform.localScale.x * 100;
            float value = 0f;
            if (attributes.AttributeDict.ContainsKey(attribute)) 
            {
                value = attributes.AttributeDict[attribute];
            }
            float change = value - scale * sliderSpeed;

            //slider.image.rectTransform.localScale.x += change / 100 * Time.deltaTime;

        }
    }
}
