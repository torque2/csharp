public class Controller<T> : Controller
{
    private readonly IService<T> _service;

    public Controller(IService<T> service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult Create(T entity)
    {
        var createdEntity = _service.Create(entity);
        return Ok(createdEntity);
    }

    [HttpGet]
    public ActionResult Read(int id)
    {
        var entity = _service.Read(id);
        return Ok(entity);
    }

    [HttpPut]
    public ActionResult Update(T entity)
    {
        var updatedEntity = _service.Update(entity);
        return Ok(updatedEntity);
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}