using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController<M> where M : BaseModel
{

    private M _model;
    
    public virtual void Setup(M model)
    {
        _model = model;
    }
}
