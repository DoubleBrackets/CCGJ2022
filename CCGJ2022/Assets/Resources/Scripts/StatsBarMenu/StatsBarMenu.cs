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
    [SerializeField]
    public SerializeablePotionAttributeDictionary poopoo;
    sealed class MyAttribute : System.Attribute
    {
        // See the attribute guidelines at
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string positionalString;
        
        // This is a positional argument
        public MyAttribute(string positionalString)
        {
            this.positionalString = positionalString;
            
            // TODO: Implement code here
            throw new System.NotImplementedException();
        }
        
        public string PositionalString
        {
            get { return positionalString; }
        }
        
        // This is a named argument
        public int NamedInt { get; set; }
    }

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
            sliders[attribute.Key].image.rectTransform.sizeDelta += new Vector2(-100,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        poopoo = attributes.AttributeDict;
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
}
