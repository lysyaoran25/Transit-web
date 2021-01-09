using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WebFormsUtilities.ValueProviders {
    public class WFMapToAttributeValueProvider : IWFValueProvider {

        /// <summary>
        /// [MapTo()] attributes from properties on this type will be used to map values.
        /// </summary>
        public Type MappingType { get; set; }
        /// <summary>
        /// Values from this object's properties will be supplied as they are mapped.
        /// </summary>
        public object ValueSource { get; set; }

        private Dictionary<string, PropertyInfo> _PropertyMapDictionary = null;

        /// <summary>
        /// Map properties using [MapTo()] attributes from the type of the supplied object,<br/>
        /// which also supplies the values. Use another overload to specify a proxy type.
        /// </summary>
        /// <param name="source">The object from which [MapTo()] attributes and property values are derived.</param>
        public WFMapToAttributeValueProvider(object source) {
            MappingType = source.GetType();
            ValueSource = source;
            MapProperties();
        }
        /// <summary>
        /// Map properties using [MapTo()] attributes from any given type,<br/>
        /// using values supplied from 'source'.
        /// </summary>
        /// <param name="t">[MapTo()] attributes from properties on this type will be used to map values.</param>
        /// <param name="source">Values from this object's properties will be supplied as they are mapped.</param>
        public WFMapToAttributeValueProvider(Type t, object source) {
            MappingType = t;
            ValueSource = source;
            MapProperties();
        }

        private void MapProperties() {
            _PropertyMapDictionary = new Dictionary<string, PropertyInfo>();
            PropertyInfo[] valueProperties = ValueSource.GetType().GetProperties();
            foreach (PropertyInfo pix in MappingType.GetProperties()) {
                foreach (MapToAttribute mta in pix.GetCustomAttributes(typeof(MapToAttribute), true)
                                    .OfType<MapToAttribute>()) {
                    foreach (string s in mta.MapToProperty) {
                        if (_PropertyMapDictionary.ContainsKey(s)) {
                            throw new Exception("Tried to map to the same property [" + mta.MapToProperty + "] twice, which is not supported.");
                        }

                        _PropertyMapDictionary.Add(s, valueProperties.First(p => p.Name == pix.Name));
                    }
                }
            }
        }

        #region IWFValueProvider Members

        /// <summary>
        /// Check if there are any properties mapped to keyName.
        /// </summary>
        /// <param name="keyName">The property name specified in [MapTo()]</param>
        /// <returns>Returns the value of the mapped property.</returns>
        public bool ContainsKey(string keyName) {
            if (_PropertyMapDictionary == null) { return false; }
            if (_PropertyMapDictionary.ContainsKey(keyName)) { return true; }
            return false;
        }

        public object KeyValue(string keyName) {
            return _PropertyMapDictionary[keyName].GetValue(ValueSource, null);
        }

        public object KeyValue(string keyName, object defaultValue) {
            if (_PropertyMapDictionary.ContainsKey(keyName)) {
                return _PropertyMapDictionary[keyName].GetValue(ValueSource, null);
            } else {
                return defaultValue;
            }
        }

        public IEnumerable<String> GetPropertyEnumerator() {
            return _PropertyMapDictionary.Keys.AsEnumerable<String>();
        }

        #endregion
    }

    /// <summary>
    /// Allows the WFMapToAttributeProvider to map properties from one type/object to another.<br/>
    /// Values that are not mapped will be ignored by this provider.<br/>
    /// Multiple properties can be mapped from the source to the destination.<br/>
    /// Valid usage:    [MapTo("DestinationPropertyName")]<br/>
    ///                 [MapTo(new string[] { "DestPropNameOne", "DestPropNameTwo" })]<br/>
    ///                 ...can also use multiple "MapTo" attributes on a single property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MapToAttribute : Attribute {
        public string[] MapToProperty { get; set; }

        public MapToAttribute(string mapToProperty) {
            MapToProperty = new string[] { mapToProperty };
        }
        public MapToAttribute(string[] mapToProperties) {
            MapToProperty = mapToProperties;
        }
    }
}
