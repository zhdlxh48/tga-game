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

[Serializable]
public class SoundAttributeDictionary : SerializableDictionary<SoundType, float> { }

[Serializable]
public class AudioClipDictionary : SerializableDictionary<string, AudioClip> { }