using System.Text.Json.Serialization;

namespace EasyGoal.Backend.WebApi.Contracts.Responses.Common;

public abstract record BaseModelResponse
{
    [JsonPropertyName("_links")] 
    public IEnumerable<ApiEndpointResponse> Links { get; set; } = [];
}
