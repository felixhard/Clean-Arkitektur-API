﻿using Domain.Models.Cats;
using MediatR;

namespace Application.Queries.Cats.GetById
{
    public class GetCatByIdQuery : IRequest<Cat>
    {
        public GetCatByIdQuery(Guid catId)
        {
            Id = catId;
        }

        public Guid Id { get; }
    }
}
