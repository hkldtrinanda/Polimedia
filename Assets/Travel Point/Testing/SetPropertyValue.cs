using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using System.Reflection;

public class SetPropertyValue : MonoBehaviour
{
    [Title("From")]
    [OnValueChanged("ReferenceChanged")]
    public GameObject reference;

    [ShowIf("@this.reference")]
    [ValueDropdown(nameof(GetAllPropertiesFromComponents))]
    public string referenceProperty;

    [ShowInInspector, PropertyOrder(-1), ReadOnly] private Component _selectedComponent => !reference || referenceProperty == "" ? null : reference.GetComponent(referenceProperty.Split("/")[0]);
    [Space(10)]
    [Title("To")]
    public GameObject toReference;

    [ShowIf("@this.toReference")]
    [ValueDropdown(nameof(GetAllPropertiesToComponents))]
    public string toProperty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerable<string> GetAllPropertiesFromComponents()
    {
        if (!reference)
        {
            return null;
        }

        IEnumerable<string> componentNames = reference.GetComponents(typeof(Component)).Select(x => x.GetType().Name);

        List<string> properties = new List<string>();
        foreach (string componentName in componentNames)
        {
            System.Type type = reference.GetComponent(componentName).GetType();
            foreach (string property in type.GetFields().Select(x => x.Name).Concat(type.GetProperties(BindingFlags.GetProperty).Select(x => x.Name)))
            {
                properties.Add(componentName + "/" + property);
            }
        }
        return properties;
    }

    private IEnumerable<string> GetAllPropertiesToComponents()
    {
        if (!toReference)
        {
            return null;
        }

        IEnumerable<Component> components = toReference.GetComponents(typeof(Component));

        List<string> properties = new List<string>();
        foreach (Component component in components)
        {
            System.Type type = component.GetType();
            foreach (string property in type.GetFields().Select(x => x.Name).Concat(type.GetProperties(BindingFlags.SetProperty).Select(x => x.Name)))
            {
                properties.Add(component.GetType().Name + "/" + property);
            }
        }
        return properties;
    }

    private void ReferenceChanged()
    {
        referenceProperty = "";
    }
}
