using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseView<M,C> : MonoBehaviour
    where M : BaseModel 
    where C : BaseController<M>, new()
{
    
    protected C _controller;
    public M _model; // TODO: can this be protected?


    protected void Create()
    {
        _controller = new C();
        _controller.Setup(_model);
    }

    protected virtual void Awake()
    {
        Create();
    }
}
