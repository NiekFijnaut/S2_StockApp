﻿using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IRecommendation
    {
        List<RecommendationDTO> GetRecommendations(string interest);
    }
}
