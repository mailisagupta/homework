using HelloWebService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathFunctionController : ControllerBase
    {

        ///public static MathFunction mathfunction = new MathFunction();
        // GET: api/<MathFunctionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MathFunctionController>/5
        [HttpGet("{id}")]
        public string Get(int id )
        {
            return "value";
        }

        // POST api/<MathFunctionController>
        [HttpPost]
        public IActionResult Post([FromBody] MathFunction value)
        {
            


            if (!string.IsNullOrEmpty(value.stringOperation) && !Char.IsWhiteSpace((char)value.charOperation) && value.charOperation != '\0')
            {
                return BadRequest("Cannot pass string and character operation together!");
            }
            
            else if (!string.IsNullOrEmpty(value.stringOperation))
            {
                if (!Enum.IsDefined(typeof(Operations), value.stringOperation) )
                {

                    return BadRequest("Invalid Operation");

                }

                else
                { 
                    switch (value.stringOperation)
                    {
                        case "Add":
                            value.Result = value.FirstOperand + value.SecondOperand;
                            break;

                        case "Subtract":
                            value.Result = value.FirstOperand - value.SecondOperand;
                            break;
                        case "Multiple":
                            value.Result = value.FirstOperand * value.SecondOperand;
                            break;
                        case "Divide":
                            try
                            {
                                value.Result = value.FirstOperand / value.SecondOperand;
                            }
                            catch (DivideByZeroException e)
                            {
                                return BadRequest(e.Message);
                            }
                            break;

                    }




                    return Ok(value);
                }

            }


            else if (!Char.IsWhiteSpace((char)value.charOperation))
            {

                if (!Enum.IsDefined(typeof(Operations), (int)(value.charOperation)))
                {

                    return BadRequest("Invalid Operation");

                }

                else
                {

                    switch (value.charOperation)
                    {
                        case '+':
                            value.Result = value.FirstOperand + value.SecondOperand;
                            break;

                        case '-':
                            value.Result = value.FirstOperand - value.SecondOperand;
                            break;
                        case '*':
                            value.Result = value.FirstOperand * value.SecondOperand;
                            break;
                        case '/':
                            try
                            {
                                value.Result = value.FirstOperand / value.SecondOperand;
                            }
                            catch (DivideByZeroException e)
                            {
                                return BadRequest(e.Message);
                            }
                            break;

                    }

                    return Ok(value);
                }
            }
           


            return Ok(value);



        }

      

        // PUT api/<MathFunctionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MathFunctionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
