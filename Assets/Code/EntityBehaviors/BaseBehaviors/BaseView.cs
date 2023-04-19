using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseView<C, M> : MonoBehaviour
    where C : BaseController, new()
    where M : BaseModel, new()
{
    
    protected C _controller;
    protected M _model;


    protected void Create()
    {
        _controller = new C();
        _model = new M();
    }

    protected virtual void Awake()
    {
        Create();
    }
}
