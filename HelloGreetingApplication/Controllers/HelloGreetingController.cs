using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;
using BusinessLayer.Service;
using BusinessLayer.Interface;
using NLog;
using RepositoryLayer.Service;

namespace HelloGreetingApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly IGreetingBL _greetingBL;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public HelloGreetingController(IGreetingBL greetingBL)
        {
            _greetingBL = greetingBL;
        }
        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>response model</returns>
        [HttpGet]
        public IActionResult Get()
        {
            logger.Info("GET request received.");
            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Hello to Greeting App API Endpoint",
                Data = "Hello World"
            };
            logger.Info("GET response: {@Response}", responseModel);
            return Ok(responseModel);
        }
        /// <summary>
        /// Post request
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpPost]
        public IActionResult Post([FromBody] RequestModel requestModel)
        {
            logger.Info($"POST request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Request received successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };

            logger.Info("POST response: {@Response}", responseModel);
            return Ok(responseModel);
        }

        /// <summary>
        /// Put request
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpPut]
        public IActionResult Put([FromBody] RequestModel requestModel)
        {
            logger.Info($"PUT request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Data Updated Successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };

            logger.Info("PUT response: {@Response}", responseModel);
            return Ok(responseModel);
        }

        /// <summary>
        /// Patch request
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>

        [HttpPatch]
        public IActionResult Patch([FromBody] RequestModel requestModel)
        {
            logger.Info($"PATCH request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var data = new
            {
                key = string.IsNullOrWhiteSpace(requestModel.Key) ? "Not updated" : requestModel.Key,
                value = string.IsNullOrWhiteSpace(requestModel.Value) ? "Not updated" : requestModel.Value
            };

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Data Updated Successfully",
                Data = $"Key: {data.key}, Value: {data.value}"
            };

            logger.Info("PATCH response: {@Response}", responseModel);
            return Ok(responseModel);
        }
        /// <summary>
        /// Delete request
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>response model</returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] RequestModel requestModel)
        {
            logger.Info($"DELETE request received: Key={requestModel.Key}, Value={requestModel.Value}");

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Data Deleted Successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };

            logger.Info("DELETE response: {@Response}", responseModel);
            return Ok(responseModel);
        }

        /// <summary>
        /// Greeting from service
        /// </summary>
        /// <returns>"Hello World</returns>

        [HttpGet("Greetings")]

        public IActionResult Greeting()
        {
            logger.Info("GET request received.");

            var response = _greetingBL.Greet();

            logger.Info("GET response: {@Response}", response);

            return Ok(response);
        }

        /// <summary>
        /// Greeting by name based on attribute provided by user
        /// </summary>
        /// <param name="greetRequest"></param>
        /// <returns>Greeting</returns>
        [HttpPost("GreetingsByName")]

        public IActionResult GreetingByName(GreetingRequestModel greetRequest)
        {
            logger.Info("GET request received.");

            var response = _greetingBL.GreetByName(greetRequest);
            logger.Info("GET response: {@Response}", response);
            return Ok(response);
        }

        /// <summary>
        ///  Add greeting message to database
        /// </summary>
        /// <param name="greetingMessage"></param>
        /// <returns>Greeting Entity</returns>
        [HttpPost]
        [Route("AddGreetingMessage")]

        public IActionResult SaveGreeting(GreetingMessageModel greetingMessage)
        {
            logger.Info("POST request received.");
            var response = _greetingBL.SaveGreeting(greetingMessage);
            logger.Info("POST response: {@Response}", response);
            return Ok(response);
        }

        /// <summary>
        /// Get greeting message by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Message</returns>
        
        [HttpGet("GetGreetingMessageByID")]

        public IActionResult GetGreetingMessageByID(int id)
        {
            logger.Info("GET request received.");
            var response = _greetingBL.GetGreetingMessageByID(id);
            if(response == null)
            {
                logger.Error("No greeting message found for ID: {id}", id);
                return NotFound("No greeting message found for ID: " + id);
            }
            logger.Info("GET response: {@Response}", response);
            return Ok(response);
        }

        ///<summary>
        ///Get messages list
        ///</summary>
        ///<returns>Messages list</returns>

        [HttpGet("GetMessagesList")]

        public IActionResult GetMessagesList()
        {
            logger.Info("GET request received.");
            var response = _greetingBL.GetMessagesList();
            if (response == null)
            {
                logger.Error("No greeting messages found");
                return NotFound("No greeting messages found");
            }
            logger.Info("GET response: {@Response}", response);
            return Ok(response);
        }
    }
}
