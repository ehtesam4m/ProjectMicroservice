using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Project.API.UseCases.Commands.CreateProject
{
    public class CreateProjectRequest
    {
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string ClientName { get; set; }
    }
}
