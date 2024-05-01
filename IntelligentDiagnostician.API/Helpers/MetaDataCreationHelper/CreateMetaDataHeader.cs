using IntelligentDiagnostician.BL.ResourceParameters;

namespace IntelligentDiagnostician.API.Helpers.MetaDataCreationHelper
{
    public static class CreateMetaDataHeader
    {
        public delegate string CreateResourceUriDelegate(string actionName, ResourceUriType resourceUriType);

        public static object AddMetaData<TDto>(PagedList<TDto> systems, string actionName,
            CreateResourceUriDelegate createResourceUri)
        {
            var previousPageLink =
                systems.HasPrevious ? createResourceUri(actionName, ResourceUriType.PreviousPage) : null;

            var nextPageLink = systems.HasNext ? createResourceUri(actionName, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = systems.TotalCount,
                pageSize = systems.PageSize,
                currentPage = systems.CurrentPage,
                totalPages = systems.TotalPages,
                previousPageLink,
                nextPageLink
            };
            return paginationMetadata;

            // Response.Headers.Append("X-Pagination",
            //     JsonHelper.SerializeWithCustomOptions(paginationMetadata));
        }
    }
}
