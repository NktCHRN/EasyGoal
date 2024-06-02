using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;
public abstract class BaseController : ControllerBase
{
    public OkObjectResult OkResponse<T>(T value)
    {
        return base.Ok(ApiResponse.FromResult(value));
    }

    public OkObjectResult OkResponse()
    {
        return base.Ok(ApiResponse.FromResult(new object()));
    }

    public NoContentResult NoContentResponse()
    {
        return base.NoContent();
    }

    public UnauthorizedObjectResult UnauthorizedResponse(ErrorResponse error)
    {
        return base.Unauthorized(ApiResponse.FromError(error));
    }
}
