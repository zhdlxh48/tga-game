using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

[Serializable]
public class PlayerPropertyDictionary : SerializableDictionary<Parameter, int> { }

[Serializable]
public class ItemPropertyDictionary : SerializableDictionary<GameObject, int> { }

[Serializable]
public class NpcAttributeDictionary : SerializableDictionary<NpcAttribute, DataTrigger> { }