using Microsoft.AspNetCore.Mvc;

namespace Presentation.Utils.Base
{
    internal record ReponseBase
    {
        internal static JsonResult DefaultResponse(bool success, string? message = null, object? objectData = null)
        {
            return BigJson(new
            {
                Success = success,
                Message = message,
                Data = objectData,
            });
        }

        internal static JsonResult BigJson(object data)
        {
            return new JsonResult(data);
        }
    }
}
