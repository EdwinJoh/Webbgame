﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DTO.MissionDtos
{
    public record MissionDto(Guid Id,string Name,int money);
    
}
