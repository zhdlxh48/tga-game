﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(PlayerPropertyDictionary))]
[CustomPropertyDrawer(typeof(ItemPropertyDictionary))]
[CustomPropertyDrawer(typeof(NpcAttributeDictionary))]
[CustomPropertyDrawer(typeof(SoundAttributeDictionary))]
[CustomPropertyDrawer(typeof(AudioClipDictionary))]

[CustomPropertyDrawer(typeof(StringStringDictionary))]
[CustomPropertyDrawer(typeof(ObjectColorDictionary))]
[CustomPropertyDrawer(typeof(StringColorArrayDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}

[CustomPropertyDrawer(typeof(ColorArrayStorage))]
public class AnySerializableDictionaryStoragePropertyDrawer: SerializableDictionaryStoragePropertyDrawer {}
