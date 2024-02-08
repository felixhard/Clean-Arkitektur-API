﻿using Application.Dtos.AnimalUsersDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.AnimalUsers.GetAll
{
    public class GetAllAnimalUsersQuery : IRequest<List<GetAllAnimalUsersDto>>
    {

    }
}
