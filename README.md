

<p align="center">
  <img src="https://renderheads-file-share.s3.af-south-1.amazonaws.com/assets/renderheads.svg" width=50%>
</p>
<p align="center">
  <b>RenderHeads ©2021</b>
</p>
<p align ="center"> Author / Maintainer: Ross Borchers </p>

# Service Locator for Unity

"The service locator pattern is a design pattern used in software development to encapsulate the processes involved in obtaining a service with a strong abstraction layer. This pattern uses a central registry known as the "service locator", which on request returns the information necessary to perform a certain task." - [Wikipedia](https://en.wikipedia.org/wiki/Service_locator_pattern)

### ServiceLocator

Used for storing, and retrieving services through `AddService`, `GetService` and `RemoveService`


### Service 

the base interface all services must inherit. Serves to signal intent and has no exposed members. 

You could extend this interface to introduce an abstraction layer on retrival of a service if required. If a MonoBehaviour is required you would need to create a new version of MonoService extending the new interfacee.

### MonoService

A MonoBehaviour servic.

`OnEnable` adds and `OnDisable` removes the service from the ServiceLocator. Remember to call these base implementations if `OnEnable` or `OnDisable`are called.


### LazyService<T>
  
A wrapper for services that allows for lazy retrival of services so you dont have to assing them manually.

eg.
```
class MyGameManager : MonoBehaviour
{
    //No explicit assignment required
    private LazyService<MyMonoService> _service;
    
    private void Start()
    {
        _service.Value.Foo();
    }
}
```

the alternative approach would be

`_service = ServiceLocator.GetService<MyMonoService>();`
