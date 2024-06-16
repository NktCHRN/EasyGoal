﻿using EasyGoal.Backend.WebApi.Contracts.Responses.Common;
using Microsoft.AspNetCore.Mvc;

namespace EasyGoal.Backend.WebApi.Controllers;
public abstract class BaseController : ControllerBase
{
    protected OkObjectResult OkResponse<T>(T value)
    {
        return base.Ok(ApiResponse.FromResult(value));
    }

    protected NoContentResult NoContentResponse()
    {
        return base.NoContent();
    }

    protected UnauthorizedObjectResult UnauthorizedResponse(ErrorResponse error)
    {
        return base.Unauthorized(ApiResponse.FromError(error));
    }
}
