namespace EasyGoal.Backend.WebApi.Contracts.Requests.Common;

public sealed record PaginationParametersRequest(int PerPage, int Page)
{
}
