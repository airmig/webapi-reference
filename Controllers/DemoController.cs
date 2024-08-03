using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;


[ApiController]
//[Route("api/[controller]")]
public class DemoController:Controller{
    [HttpGet]
    [Route("testroute/all")]
    public IActionResult SampleAPIMethod(){
        return StatusCode(200, "Sample response text");
    }

    [HttpGet]
    [Route("testroute/{id:int}")]
    public IActionResult SampleAPIMethod2(int id){
        return StatusCode(200, "Id pass is" + id.ToString());
    }
}