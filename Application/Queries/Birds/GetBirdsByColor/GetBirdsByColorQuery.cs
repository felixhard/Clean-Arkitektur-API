using Domain.Models.Animals.Birds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Birds.GetBirdsByColor
{
    public class GetBirdsByColorQuery : IRequest<List<Bird>>
    {
        public required string Color { get; set; }
    }
}
