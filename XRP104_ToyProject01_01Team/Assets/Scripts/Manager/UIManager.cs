using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private readonly Dictionary<Type, IUI> _uis = new();

    private void Awake() => SingletonInit();

    public void Register<T>(T ui) where T : class, IUI
    {
        if (ui == null) return;
        _uis[typeof(T)] = ui;
    }

    public bool TryGet<T>(out T ui) where T : class, IUI
    {
        ui = null;
        if (!_uis.ContainsKey(typeof(T))) return false;
        
        ui = _uis[typeof(T)] as T;
        return true;
    }

    public void Unregister<T>() where T : class, IUI
    {
        _uis.Remove(typeof(T));
    }
}
