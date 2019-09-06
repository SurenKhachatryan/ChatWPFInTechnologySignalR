using BLL.Core;
using DAL.Models;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Mappers.ErrorMappers
{
    public static class ErrorMappers
    {
        public static ErrorModelDto MapToErrorModelDto(this ErrorModel model)
        {
            if (model == null)
                return null;

            return new ErrorModelDto()
            {
                Code = model.Code,
                Description = model.Description
            };
        }

        public static List<ErrorModelDto> MapToErrorModelDtos(this List<ErrorModel> models)
        {
            if (models != null)
                return models.Select(MapToErrorModelDto).ToList();

            return new List<ErrorModelDto>();
        }
    }
}
