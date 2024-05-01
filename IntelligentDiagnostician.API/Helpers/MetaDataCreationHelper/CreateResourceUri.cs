// using Microsoft.AspNetCore.Mvc;
// using IntelligentDiagnostician.BL.ResourceParameters;
//
// namespace IntelligentDiagnostician.API.Helpers.MetaDataCreationHelper;
//
// public static class CreateResourceUri
// {
//     public static string? CreateCarSystemResourceUri(
//         CarSystemsResourceParameters resourceParameters,
//         ResourceUriType type,
//         string routeName,
//         IUrlHelper urlHelper)
//     {
//         switch (type)
//         {
//             case ResourceUriType.PreviousPage:
//                 return urlHelper.Link(routeName,
//                     new
//                     {
//                         pageNumber = resourceParameters.PageNumber - 1,
//                         pageSize = resourceParameters.PageSize,
//                         carSystemName = resourceParameters.CarSystemName,
//                         searchQuery = resourceParameters.SearchQuery,
//                     });
//             case ResourceUriType.NextPage:
//                 return urlHelper.Link(routeName,
//                     new
//                     {
//                         pageNumber = resourceParameters.PageNumber + 1,
//                         pageSize = resourceParameters.PageSize,
//                         carSystemName = resourceParameters.CarSystemName,
//                         // searchQuery = resourceParameters.SearchQuery
//                     });
//             default:
//                 return urlHelper.Link(routeName,
//                     new
//                     {
//                         pageNumber = resourceParameters.PageNumber,
//                         pageSize = resourceParameters.PageSize,
//                         carSystemName = resourceParameters.CarSystemName,
//                         searchQuery = resourceParameters.SearchQuery
//                     });
//         }
//     
//     }
//     
//     public static string? CreateSensorResourceUri(
//         SensorsResourceParameters resourceParameters,
//         ResourceUriType type,
//         string routeName,
//         IUrlHelper urlHelper)
//     {
//         switch (type)
//         {
//             case ResourceUriType.PreviousPage:
//                 return urlHelper.Link(routeName,
//                     new
//                     {
//                         pageNumber = resourceParameters.PageNumber - 1,
//                         pageSize = resourceParameters.PageSize,
//                         sensorName = resourceParameters.SensorName,
//                         searchQuery = resourceParameters.SearchQuery,
//                     });
//             case ResourceUriType.NextPage:
//                 return urlHelper.Link(routeName,
//                     new
//                     {
//                         pageNumber = resourceParameters.PageNumber + 1,
//                         pageSize = resourceParameters.PageSize,
//                         sensorName = resourceParameters.SensorName,
//                         // searchQuery = resourceParameters.SearchQuery
//                     });
//             default:
//                 return urlHelper.Link(routeName,
//                     new
//                     {
//                         pageNumber = resourceParameters.PageNumber,
//                         pageSize = resourceParameters.PageSize,
//                         sensorName = resourceParameters.SensorName,
//                         searchQuery = resourceParameters.SearchQuery
//                     });
//         }
//     }
// }
